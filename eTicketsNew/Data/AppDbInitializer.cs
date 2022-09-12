using eTicketsNew.Data.Static;
using eTicketsNew.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsNew.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Stage
                if (!context.Stages.Any())
                {
                    context.Stages.AddRange(new List<Stage>()
                    {
                        new Stage()
                        {
                            Name = "Stage 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first Stage"
                        },
                        new Stage()
                        {
                            Name = "Stage 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the second Stage"
                        },
                        new Stage()
                        {
                            Name = "Stage 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the therd Stage"
                        }
                    });
                    context.SaveChanges();
                }

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the therd actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                //Directors
                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director()
                        {
                            FullName = "Director 1",
                            Bio = "This is the Bio of the first director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Director()
                        {
                            FullName = "Director 1",
                            Bio = "This is the Bio of the second director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Director()
                        {
                            FullName = "Director 1",
                            Bio = "This is the Bio of the therd director",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        }

                    });
                    context.SaveChanges();
                }

                //Plays
                if (!context.Plays.Any())
                {
                    context.Plays.AddRange(new List<Play>()
                    {
                        new Play()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            StageId = 3,
                            DirectorId = 3,
                            PlayCategory = Enums.PlayCategory.Drama
                        },
                        new Play()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Life movie description",
                            Price = 39.51,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            StageId = 3,
                            DirectorId = 3,
                            PlayCategory = Enums.PlayCategory.Musical
                        },
                        new Play()
                        {
                            Name = "Ghost",
                            Description = "This is the Life movie description",
                            Price = 39.52,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            StageId = 3,
                            DirectorId = 3,
                            PlayCategory = Enums.PlayCategory.Tragedy
                        }

                    });
                    context.SaveChanges();
                }

                //Actors & Plays
                if (!context.Actors_Plays.Any())
                {
                    context.Actors_Plays.AddRange(new List<Actor_Play>()
                    {
                        new Actor_Play()
                        {
                            ActorId = 1,
                            PlayId = 1
                        },
                        new Actor_Play()
                        {
                            ActorId = 1,
                            PlayId = 2
                        },
                        new Actor_Play()
                        {
                            ActorId = 1,
                            PlayId = 3
                        },
                        new Actor_Play()
                        {
                            ActorId = 2,
                            PlayId = 2
                        },
                        new Actor_Play()
                        {
                            ActorId = 3,
                            PlayId = 3
                        }
                    });
                    context.SaveChanges();
                }
            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users

                //AdminUser
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@admin.ru";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //SimpleUser
                string appUserEmail = "user@user.ru";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "4321");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

            }
        }
    }
}
