using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ticketer.Data; 
using ticketer.Models;
using ticketer.Data.Enums;
namespace ticketer.Data
{
    public class AppDbIntializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();

                // Cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTs9x0yZUbJHluAawK_1JGoAvoSfnZkZwpWjg&s",
                            Name = "Renaissance Cinemas Alex",
                            Address = "San Stefano, Alexandria"
                        },
                        new Cinema()
                        {
                            Logo = "https://liteway-lighting.com/wp-content/uploads/2020/09/Delta-20-scaled.jpg",
                            Name = "Renaissance Cinemas Madinaty",
                            Address = "Open Air Mall, Madinaty, New Cairo"
                        },
                        new Cinema()
                        {
                            Logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqFVmTGA3AHc7safqLiVGM0eoE3v5zvghe1g&s",
                            Name = "Renaissance Cinemas Al Rehab City",
                            Address = "Mall 1, Al Rehab City, New Cairo"
                        },
                        new Cinema()
                        {
                             Logo = "https://assets.cairo360.com/app/uploads/2010/02/rnc-downtwon.png",
                             Name = "Renaissance Cinemas Downtown Cairo",
                             Address = "8 Emad El Din Street, Downtown, Cairo"
                        },
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
                            FullName = "Ahmed Helmy",
                            Bio = "Ahmed Helmy made his first big screen appearance in film Aboud on the Boarder (1999), in which he co-starred alongside Alaa Waley El Din. Ahmed, through his amazing breakthrough performance, and comic sense of humor, nabbed all the attention he needed in this film. He quickly made a jump to starring roles in films such as Umar 2000 (2000), The Headmaster (2000)",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSzgFVCdF1HnElqCBnxgyJtbRy-yUVHUv4PVcfnFfKjqsqRk6kJXAuF-iNXo8PlNI1kLt7YJ58kBiUkUkQRyTMzQw"

                        },
                        new Actor()
                        {
                            FullName = "Mohamed Henedy",
                            Bio = "Mohamed Henedi was born on 1 February 1965 in Egypt. He is an actor, known for Ismailia Rayeh Gay (1997), El-Huroob (1991) and Bilyah wa Demaghuh el-Alyah (2000). He has been married to Abeer Al-Sari Mudif Al-Asaad since 18 November 1999. They have three children.",
                            ProfilePictureURL = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSnpvOqMD1P-HGcqsqevt8fGQ60agUGm3cAeJ7GuDEoRvmkJi1ekE5x-S4ZqAQWBKIgnOZ_ZKhsK5qQTFOEly-PWg"
                        },
                        new Actor()
                        {
                            FullName = "Ahmed El-Fishawy",
                            Bio = "Ahmad Farouk Al Fishawy grew up amongst some of the top artists in the region. With famed actors Farouk Al Fishawy and Somaya El Alfy as birth parents, it was inevitable for Al Fishawy to find his calling in the arts. Born on November 11th, Al Fishawy started his cinematic/TV career at a very early age, making him today an A-lister entertainment name in the movie, TV and music industry. His production company, Crystal Dog, and as of 2015 invested in creating content for the silver screens.",
                            ProfilePictureURL = "https://media.themoviedb.org/t/p/w500/4bmLaXHBRZi6Sn6XE1eCAM6KDs0.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Karim Abdel Aziz",
                            Bio = "Karim Abdel Aziz was born in Egypt on 17-8-1975. He was raised by his father the director Mohamed Abdel Aziz who has a valuable history in the Egyptian cinema; hence the technical environment in which he grew up had a prominent role in the ease of entry and work in the field of cinematography. Karim graduated from the Academy of Arts in 1997 as a director; he worked as an assistant director for a brief period until he discovered that he felt pleasure to stand in front of the camera and by then he decided to enter the world of acting.",
                            ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMTc5MjEyNTQ4OF5BMl5BanBnXkFtZTgwNzM1MTUzMjE@._V1_.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Hani Ramzy",
                            Bio = "Hani Ramzi was born on 26 October 1964 in Cairo, Egypt. He is an actor, known for Nims Bond (2008), The Mysterious Man by himself (2010) and Ghabi Minnuh Fih (2004). He is married to Mona Mohab Kamel. They have two children.",
                            ProfilePictureURL = "https://image.tmdb.org/t/p/w300/r0RMbUmnBuRbwLLFat60eBFq4B4.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Mohamed Saad",
                            Bio = "Muhammad Sad was born on 14 December 1968 in Giza, Egypt. He is an actor and writer, known for Ellembi (2002), The Headmaster (2000) and The Treasure 2 (2019).",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_2c493aba02be3769b01df2e8b82a83acb80dac30fca1019d219f5a03b182455a.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Nour",
                            Bio = "With a smile that melts hearts and looks that catch all eyes, Lebanese actress Nour made quite an impression on audiences from her first roles in Egyptian films, TV series, and plays.\r\n",
                            ProfilePictureURL = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcR_n9Zh-nsay_pAEBw9t6dmKAYPSoGkWuTlPlLwRGe9AMQ28YZ7C53Nzor3c-g8AoiCc2TCx1B9OkIMAcTHIIAjkA"
                        }

                    });
                    context.SaveChanges();

                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Khalid Hassan",
                            Bio = "An artistic producer who has participated in many different artistic works. Khaled Hassan's works have varied between television series and films. Among the most important films in which he participated as an artistic producer is the film (Forced Escape). Khaled Hassan participated as a production manager in a number of films, including the films (You Made Me a Criminal) and the films (Industrial Bump).",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTv7c_rgMn64Ubi_BMbxKU0wfUsy43vFROExA&s"

                        },
                        new Producer()
                        {
                            FullName = "Esaad Youness",
                            Bio = "An Egyptian actress, writer, broadcaster and producer, born in Cairo in 1950. She obtained a bachelor's degree from the Institute of Tourist Guidance. During her university studies, specifically in the first year of the Institute of Tourism in 1968, she applied for a job in the radio in the European program, then worked as an assistant in the Middle East program and then trained until she became a broadcaster presenting live programs. She married the artist (Nabil Al-Hijrasy).",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_d2826f1c0877cdf32a1cdfdacbf04abbe387e1fb3ce1e56b08fc19221bbcdb80.jpg"
                        },
                        new Producer()
                        {
                            FullName = "New Century Art Productions",
                            Bio = "In 2004, New Century was established to keep up with the new cinematic technology and to present high-quality works. Its first film was “The Seventh Sense” in 2004, starring Ahmed El-Fishawy. It continued on this path, producing “True Dreams” in 2007, through which it introduced the writer and screenwriter Mohamed Diab in his first cinematic work. This was repeated with director Mohamed Hamdy in the film “The Suspect” in 2009.",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_d9015b5845c2cd32f413317669fc4b3e4475e05e9f2fb5c47910c1b7c7fa981e.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Hisham Soliman",
                            Bio = "An Egyptian producer, he was born on September 29, 1967, in Cairo, specifically in the Zamalek district. He studied at Amon School and graduated from the Faculty of Commerce at Cairo University in 1988. He then joined the Production Department at the Higher Institute of Cinema to continue his studies. He began his career in production in the 1980s as a production assistant, and later worked his way up the ranks. One of the most important works he participated in early in his career was Youssef Chahine's film \"The Immigrant,\" in which he worked as a production manager. He later participated in the production of several important Egyptian and international films, as well as numerous major commercials. He participated in films such as \"Destiny,\" \"Concerto in Darb Sa'ada,\" and \"Mido Mashakel.\"",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_d303fc1647ac056ba26609690d3a78cd2b570d814622c05a594d808285e90041.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Thaer Youness",
                            Bio = "Thaer Younis, an Egyptian production manager, has worked on a number of artistic works, including: One of the People (2006), and the film At Cairo Station (2006), in which he also acted.",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_4c71e3c37c741171b6c583c6a8a21a6685c0207c372ac4672bb6f08fa9aaf7a0.jpg"
                        },
                         new Producer()
                        {
                            FullName = "Al Sobbky",
                            Bio = "Ahmed Al Sabbky is an Egyptian producer, most of his films have been quite successful at the box office despite being subject to attacks from critics. Al Sabbky states that his works seek to engage the working classes from which he originates, thus he adds that he knows how to connect with normal moviegoers. Nonetheless Al Sabbky is constantly attacked by critics who describe his works as base and unsubstantial. Despite the views of critics Al Sabbky’s works are nonetheless very successful at the box office.",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_3b5d64df4107b6329983ea3837213758e5aee7e03459f3194133f697bcddd008.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Matab Sinay ",
                            Description = "Galal (aka “Mimi”) leaves his father in Ismailia seeking fortune in Cairo. Working as a construction foreman, he one day rescues Zeina – the daughter of businessman Farouk – from drowning. Mimi becomes Zeina’s tutor, but when Farouk is attacked and falls into a coma, Mimi must step up to save Farouk’s company while navigating the complications of his romance with Zeina",
                            ImageURL = "https://media0078.elcinema.com/uploads/_315x420_aec1a0115f9f158ea12416fbe20dca3dac0dca52589f09527882802f966ed46a.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=GNjPQ0FDV-g",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 1,
                            ReleaseDate = new DateTime(2006)         
                        },
                        new Movie()
                        {
                            Name = "El-Limby",
                            Description = "El-Limby is a simple, comic-hearted man living with his mother in a run-down Cairo neighborhood. He falls in love with his neighbor Nosa (Hala Shiha), but her father objects to the match. El-Limby’s mother urges him to find a job and improve himself, leading to a series of comic adventures as he tries to prove himself and win Nosa’s hand",
                            ImageURL = "https://i.ytimg.com/vi/M9dM0ZW9AXc/maxresdefault.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=_EXkWCtGGJo",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 6,
                            ReleaseDate = new DateTime(2002)

                        },
                         new Movie()
                        {
                            Name = "Amir El-Bahar ",
                            Description = "Amir (Henedy) is a reckless Naval Academy cadet who falls for Salwa (Sherin Adel), the girl of his dreams, but she only sees him as a friend. When his meddling commander and Salwa’s father Nizar (Yasser Galal) discovers Amir’s feelings, he objects and concocts obstacles. After a dangerous naval mission changes everything, Amir must fight to win Salwa’s affection",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/ar/d/d5/%D9%85%D9%84%D8%B5%D9%82_%D9%81%D9%84%D9%85_%D8%A3%D9%85%D9%8A%D8%B1_%D8%A7%D9%84%D8%A8%D8%AD%D8%A7%D8%B1_%282009%29.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=rg1ESFVB-lo",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 2,
                            ReleaseDate = new DateTime(2009)

                        },
                         new Movie()
                         {
                            Name = "El Hassa El Sabaa",
                            Description = "Yehia (El-Fishawy) is a poor youth obsessed with kung fu, dreaming of becoming Egypt’s champion. Frustrated that kung fu has no future in Egypt, he challenges the world champion to regain honor. During his journey he encounters a mystical fortune-teller (Rania Kurdi) who claims he must unlock the “seventh sense” to succeed. The film follows Yehia’s comic struggles as he pursues martial-arts glory",
                            ImageURL = "https://i1.sndcdn.com/artworks-000107784931-lvueua-t500x500.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=a4A46LfSH4k",
                            MovieCategory = MovieCategory.Drama,
                            ProducerId = 3,
                            ReleaseDate = new DateTime(2005)

                         },
                          new Movie()
                         {
                            Name = "Ayiz Haqi",
                            Description = "A down-to-earth, struggling taxi driver (Ramzi) discovers, by sheer chance, that his country's constitution grants him a share in the nation's entire public property. He proceeds to collecting power-of-attorney documents from over 50% of the population in order to literally sell out the country so that he could get married.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMDgxOTY4NzgtMDBhNS00MGNiLWFhYzgtYzUyYzkzOTgzZWNmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=G_MCx1yteX8",
                            MovieCategory = MovieCategory.Drama,
                            ProducerId = 4,
                            ReleaseDate = new DateTime(2008)
                         },
                           new Movie()
                         {
                            Name = "Zarf Tareq",
                            Description = "A careless telecom employee, Tarek (Helmy), is assigned by his boss Fadi (El-Sawy) to investigate a woman named Sara (Nour). Tarek finds Sara and falls in love with her, delaying his report to Fadi. Fadi, who also loves Sara, mistakenly believes Sara is the person he’s searching for and tries to sabotage Tarek’s romance.",
                            ImageURL = "https://media0078.elcinema.com/uploads/_315x420_18f0d7ee0bff8413a22832ef53ddcb7740b452efa1f1fb2a9b59230385164305.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=8937ZgC0FcY",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 5,
                            ReleaseDate = new DateTime(2006)
                         }
                    });
                    context.SaveChanges();
                }
                if (!context.MovieActors.Any())
                {
                    context.MovieActors.AddRange(new List<MovieActor>()
                    {
                        new MovieActor()
                        {
                            ActorId = 1,
                            MovieId = 1,
                            RoleName= "Glal"
                        },
                        new MovieActor()
                        {
                            ActorId = 7,
                            MovieId = 1,
                            RoleName= "Mai"
                        },
                        new MovieActor()
                        {
                            ActorId = 6,
                            MovieId = 2,
                            RoleName= "EL-Lemby"
                        },
                        new MovieActor()
                        {
                            ActorId = 2,
                            MovieId = 3,
                            RoleName= "Amir"
                        },
                        new MovieActor()
                        {
                            ActorId = 3,
                            MovieId = 4,
                            RoleName= "Yahia El Masry"
                        },
                         new MovieActor()
                        {
                            ActorId = 5,
                            MovieId = 5,
                            RoleName= "Saber"
                        },
                         new MovieActor()
                        {
                            ActorId = 1,
                            MovieId = 6,
                            RoleName= "Tarek"
                        },
                        new MovieActor()
                        {
                            ActorId = 7,
                            MovieId = 6,
                            RoleName= "Sara"
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
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Create roles
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                // Create admin user
                var adminEmail = "admin@yourapp.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user, "YourSecurePassword123!");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
