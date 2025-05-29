using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ticketer.Data;
using ticketer.Models;
using ticketer.Data.Enums;
using ticketer.Data.Static;
namespace ticketer.Data
{
    public class AppDbInitializer
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
                        new Actor()//1
                        {
                            FullName = "Ahmed Helmy",
                            Bio = "Ahmed Helmy made his first big screen appearance in film Aboud on the Boarder (1999), in which he co-starred alongside Alaa Waley El Din. Ahmed, through his amazing breakthrough performance, and comic sense of humor, nabbed all the attention he needed in this film. He quickly made a jump to starring roles in films such as Umar 2000 (2000), The Headmaster (2000)",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSzgFVCdF1HnElqCBnxgyJtbRy-yUVHUv4PVcfnFfKjqsqRk6kJXAuF-iNXo8PlNI1kLt7YJ58kBiUkUkQRyTMzQw"

                        },
                        new Actor()//2
                        {
                            FullName = "Mohamed Henedy",
                            Bio = "Mohamed Henedi was born on 1 February 1965 in Egypt. He is an actor, known for Ismailia Rayeh Gay (1997), El-Huroob (1991) and Bilyah wa Demaghuh el-Alyah (2000). He has been married to Abeer Al-Sari Mudif Al-Asaad since 18 November 1999. They have three children.",
                            ProfilePictureURL = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSnpvOqMD1P-HGcqsqevt8fGQ60agUGm3cAeJ7GuDEoRvmkJi1ekE5x-S4ZqAQWBKIgnOZ_ZKhsK5qQTFOEly-PWg"
                        },
                        new Actor()//3
                        {
                            FullName = "Ahmed El-Fishawy",
                            Bio = "Ahmad Farouk Al Fishawy grew up amongst some of the top artists in the region. With famed actors Farouk Al Fishawy and Somaya El Alfy as birth parents, it was inevitable for Al Fishawy to find his calling in the arts. Born on November 11th, Al Fishawy started his cinematic/TV career at a very early age, making him today an A-lister entertainment name in the movie, TV and music industry. His production company, Crystal Dog, and as of 2015 invested in creating content for the silver screens.",
                            ProfilePictureURL = "https://media.themoviedb.org/t/p/w500/4bmLaXHBRZi6Sn6XE1eCAM6KDs0.jpg"
                        },
                        new Actor()//4
                        {
                            FullName = "Karim Abdel Aziz",
                            Bio = "Karim Abdel Aziz was born in Egypt on 17-8-1975. He was raised by his father the director Mohamed Abdel Aziz who has a valuable history in the Egyptian cinema; hence the technical environment in which he grew up had a prominent role in the ease of entry and work in the field of cinematography. Karim graduated from the Academy of Arts in 1997 as a director; he worked as an assistant director for a brief period until he discovered that he felt pleasure to stand in front of the camera and by then he decided to enter the world of acting.",
                            ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMTc5MjEyNTQ4OF5BMl5BanBnXkFtZTgwNzM1MTUzMjE@._V1_.jpg"
                        },
                        new Actor()//5
                        {
                            FullName = "Hani Ramzy",
                            Bio = "Hani Ramzi was born on 26 October 1964 in Cairo, Egypt. He is an actor, known for Nims Bond (2008), The Mysterious Man by himself (2010) and Ghabi Minnuh Fih (2004). He is married to Mona Mohab Kamel. They have two children.",
                            ProfilePictureURL = "https://image.tmdb.org/t/p/w300/r0RMbUmnBuRbwLLFat60eBFq4B4.jpg"
                        },
                        new Actor()//6
                        {
                            FullName = "Mohamed Saad",
                            Bio = "Muhammad Sad was born on 14 December 1968 in Giza, Egypt. He is an actor and writer, known for Ellembi (2002), The Headmaster (2000) and The Treasure 2 (2019).",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_2c493aba02be3769b01df2e8b82a83acb80dac30fca1019d219f5a03b182455a.jpg"
                        },
                        new Actor()//7
                        {
                            FullName = "Nour",
                            Bio = "With a smile that melts hearts and looks that catch all eyes, Lebanese actress Nour made quite an impression on audiences from her first roles in Egyptian films, TV series, and plays.\r\n",
                            ProfilePictureURL = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcR_n9Zh-nsay_pAEBw9t6dmKAYPSoGkWuTlPlLwRGe9AMQ28YZ7C53Nzor3c-g8AoiCc2TCx1B9OkIMAcTHIIAjkA"
                        },
                         new Actor()//8
                        {
                            FullName = "Macaulay Culkin",
                            Bio = "Macaulay Macaulay Culkin Culkin is an American actor and musician. Considered one of the most successful child actors of the 1990s, Culkin has received a Golden Globe Award nomination and other accolades",
                            ProfilePictureURL = "https://www.beaconjournal.com/gcdn/authoring/authoring-images/2023/11/29/USAT/71744352007-home-alone.JPG?width=660&height=988&fit=crop&format=pjpg&auto=webp"
                        },
                        new Actor()//9
                        {
                            FullName = "Jackie Chan\r\n",
                            Bio = "Hong Kong's cheeky, lovable and best-known film star, Jackie Chan endured many years of long, hard work and multiple injuries to establish international success after his start in Hong Kong's manic martial arts cinema industry.",
                            ProfilePictureURL = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQb7T2Zf1cC--hO3O2jJEKVaG20D6ZPJlYv8IihGzV81PKI605PRyd62mF-9Nr09ZZKki718q-hDYwaFT2GJEBfgw"
                        }
                        ,
                        new Actor()//10
                        {
                            FullName = "Jaden Smith",
                            Bio = "Jaden Christopher Syre Smith is an American rapper and actor. The son of Jada Pinkett-Smith and Will Smith, he has received various accolades, including a Teen Choice Award, an MTV Movie Award, a BET Award and a Young Artist Award.",
                            ProfilePictureURL = "https://media.npr.org/assets/artslife/movies/2010/06/the-karate-kid/smith-133c75eeaa22dd073c50c907cd2844bf0c25f6e9.jpg"
                        },
                        
                        new Actor()//11
                        {
                            FullName = "Daniel Radcliffe\r\n",
                            Bio = "Daniel Jacob Radcliffe is an English actor. Radcliffe rose to fame at age twelve for portraying the title character in the Harry Potter film series. He starred in all eight films in the series, from Harry Potter and the Philosopher's Stone to Harry Potter and the Deathly Hallows",
                            ProfilePictureURL = "https://i.insider.com/579f9175d7c3dbe72f8b47f8?width=800&format=jpeg&auto=webp"
                        },
                        
                        new Actor()//12
                        {
                            FullName = "Emma Watson",
                            Bio = "Emma Charlotte Duerre Watson is an English actress. Known for her roles in both blockbusters and independent films, she has received a selection of accolades, including a Young Artist Award and three MTV Movie Awards.",
                            ProfilePictureURL = "https://people.com/thmb/RpnNLplOGndVrTF-rdBlp0biuxE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(719x39:721x41)/Emma-Watson-c59dff78899047bb839b894665b85a13.jpg"
                        },
                        
                        new Actor()//13
                        {
                            FullName = "Emma Stone",
                            Bio = "Emily Jean \"Emma\" Stone is an American actress and film producer. Her accolades include two Academy Awards, two British Academy Film Awards, and two Golden Globe Awards. In 2017, she was the world's highest-paid actress and named by Time magazine as one of the 100 most influential people in the world.",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSTjCZFA66JXAzA7DKfj2ltseAWz2NGsKV3Wptp1SY73lhlHRLCQbkC0gd-9OFxRG9lvlIZlYrbp5F6_Vl_9CLxw"
                        }
                    });
                    context.SaveChanges();

                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()//1
                        {
                            FullName = "Khalid Hassan",
                            Bio = "An artistic producer who has participated in many different artistic works. Khaled Hassan's works have varied between television series and films. Among the most important films in which he participated as an artistic producer is the film (Forced Escape). Khaled Hassan participated as a production manager in a number of films, including the films (You Made Me a Criminal) and the films (Industrial Bump).",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTv7c_rgMn64Ubi_BMbxKU0wfUsy43vFROExA&s"

                        },
                        new Producer()//2
                        {
                            FullName = "Esaad Youness",
                            Bio = "An Egyptian actress, writer, broadcaster and producer, born in Cairo in 1950. She obtained a bachelor's degree from the Institute of Tourist Guidance. During her university studies, specifically in the first year of the Institute of Tourism in 1968, she applied for a job in the radio in the European program, then worked as an assistant in the Middle East program and then trained until she became a broadcaster presenting live programs. She married the artist (Nabil Al-Hijrasy).",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_d2826f1c0877cdf32a1cdfdacbf04abbe387e1fb3ce1e56b08fc19221bbcdb80.jpg"
                        },
                        new Producer()//3
                        {
                            FullName = "New Century Art Productions",
                            Bio = "In 2004, New Century was established to keep up with the new cinematic technology and to present high-quality works. Its first film was “The Seventh Sense” in 2004, starring Ahmed El-Fishawy. It continued on this path, producing “True Dreams” in 2007, through which it introduced the writer and screenwriter Mohamed Diab in his first cinematic work. This was repeated with director Mohamed Hamdy in the film “The Suspect” in 2009.",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_d9015b5845c2cd32f413317669fc4b3e4475e05e9f2fb5c47910c1b7c7fa981e.jpg"
                        },
                        new Producer()//4
                        {
                            FullName = "Hisham Soliman",
                            Bio = "An Egyptian producer, he was born on September 29, 1967, in Cairo, specifically in the Zamalek district. He studied at Amon School and graduated from the Faculty of Commerce at Cairo University in 1988. He then joined the Production Department at the Higher Institute of Cinema to continue his studies. He began his career in production in the 1980s as a production assistant, and later worked his way up the ranks. One of the most important works he participated in early in his career was Youssef Chahine's film \"The Immigrant,\" in which he worked as a production manager. He later participated in the production of several important Egyptian and international films, as well as numerous major commercials. He participated in films such as \"Destiny,\" \"Concerto in Darb Sa'ada,\" and \"Mido Mashakel.\"",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_d303fc1647ac056ba26609690d3a78cd2b570d814622c05a594d808285e90041.jpg"
                        },
                        new Producer()//5
                        {
                            FullName = "Thaer Youness",
                            Bio = "Thaer Younis, an Egyptian production manager, has worked on a number of artistic works, including: One of the People (2006), and the film At Cairo Station (2006), in which he also acted.",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_4c71e3c37c741171b6c583c6a8a21a6685c0207c372ac4672bb6f08fa9aaf7a0.jpg"
                        },
                         new Producer()//6
                        {
                            FullName = "Al Sobbky",
                            Bio = "Ahmed Al Sabbky is an Egyptian producer, most of his films have been quite successful at the box office despite being subject to attacks from critics. Al Sabbky states that his works seek to engage the working classes from which he originates, thus he adds that he knows how to connect with normal moviegoers. Nonetheless Al Sabbky is constantly attacked by critics who describe his works as base and unsubstantial. Despite the views of critics Al Sabbky’s works are nonetheless very successful at the box office.",
                            ProfilePictureURL = "https://media0078.elcinema.com/uploads/_315x420_3b5d64df4107b6329983ea3837213758e5aee7e03459f3194133f697bcddd008.jpg"
                        }
                         ,
                          new Producer()//7
                        {
                            FullName = "Pixar",
                            Bio = "an American animation studio based in Emeryville, California, known for its critically and commercially successful computer-animated feature films.",
                            ProfilePictureURL = "https://static.wikia.nocookie.net/pixar/images/d/d0/Pixarlogo.jpg/revision/latest?cb=20100712043022"
                        }
                          ,
                          new Producer()//8
                        {
                            FullName = "Disney",
                            Bio = "For 100 years, The Walt Disney Studios has been the foundation on which The Walt Disney Company was built. Today it brings quality movies, episodic storytelling, and stage plays to consumers throughout the world. The Walt Disney Studios encompasses a collection of respected film studios, including Disney, Walt Disney Animation Studios, Pixar Animation Studios, Lucasfilm, Marvel Studios, Searchlight Pictures, and 20th Century Studios. It is also home to Disney Theatrical Group, producer of world-class stage shows, as well as Disney Music Group.",
                            ProfilePictureURL = "https://i.scdn.co/image/ab6761610000e5ebc698d53b77db34027b00f853"
                        },
                          new Producer()//9
                          {
                              FullName ="20th Century Studios",
                              Bio="It was founded by the merger of Fox Films and 20th Century Pictures in 1935. The film company is owned by Fox, a conglomerate that owns properties in the film, news, television, and music industries. 20th Century Fox is a subordinate division of 21st Century Fox, Fox's television network.",
                              ProfilePictureURL="https://fox2now.com/wp-content/uploads/sites/14/2020/01/hypatia-h_dc2ba16d85745295d3780265dfb3d8a2-h_10ba55804ded41e7e8ac68e15e782c95.jpg?w=2560&h=1440&crop=1"
                          }
                          ,
                           new Producer()//10
                          {
                              FullName ="Columbia Pictures",
                              Bio= "Columbia Pictures is an American film production and distribution company that is the flagship unit of the Sony Pictures Motion Picture Group",
                              ProfilePictureURL="https://static.wikia.nocookie.net/sony-pictures-entertaiment/images/d/df/COLUMBIA_PICTURES_ARTWORK.png/revision/latest?cb=20150208095003"
                          },
                            new Producer()//11
                            {
                                FullName ="Warner Bros",
                                Bio="Warner Bros. Entertainment Inc. (WBEI), commonly known as Warner Bros. (WB), is an American film and entertainment studio.",
                                ProfilePictureURL="https://production786.wordpress.com/wp-content/uploads/2016/10/0.jpg"
                             }

                    });
                    context.SaveChanges();
                }
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()//1
                        {
                            Name = "Matab Sinay ",
                            Description = "Galal (aka “Mimi”) leaves his father in Ismailia seeking fortune in Cairo. Working as a construction foreman, he one day rescues Zeina – the daughter of businessman Farouk – from drowning. Mimi becomes Zeina’s tutor, but when Farouk is attacked and falls into a coma, Mimi must step up to save Farouk’s company while navigating the complications of his romance with Zeina",
                            ImageURL = "https://media0078.elcinema.com/uploads/_315x420_aec1a0115f9f158ea12416fbe20dca3dac0dca52589f09527882802f966ed46a.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=GNjPQ0FDV-g",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 1,
                            ReleaseDate = new DateTime(2006, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Movie()//2
                        {
                            Name = "El-Limby",
                            Description = "El-Limby is a simple, comic-hearted man living with his mother in a run-down Cairo neighborhood. He falls in love with his neighbor Nosa (Hala Shiha), but her father objects to the match. El-Limby’s mother urges him to find a job and improve himself, leading to a series of comic adventures as he tries to prove himself and win Nosa’s hand",
                            ImageURL = "https://i.ytimg.com/vi/M9dM0ZW9AXc/maxresdefault.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=_EXkWCtGGJo",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 6,
                            ReleaseDate = new DateTime(2002, 1, 1, 0, 0, 0, DateTimeKind.Utc)

                        },
                         new Movie()//3
                        {
                            Name = "Amir El-Bahar ",
                            Description = "Amir (Henedy) is a reckless Naval Academy cadet who falls for Salwa (Sherin Adel), the girl of his dreams, but she only sees him as a friend. When his meddling commander and Salwa’s father Nizar (Yasser Galal) discovers Amir’s feelings, he objects and concocts obstacles. After a dangerous naval mission changes everything, Amir must fight to win Salwa’s affection",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/ar/d/d5/%D9%85%D9%84%D8%B5%D9%82_%D9%81%D9%84%D9%85_%D8%A3%D9%85%D9%8A%D8%B1_%D8%A7%D9%84%D8%A8%D8%AD%D8%A7%D8%B1_%282009%29.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=rg1ESFVB-lo",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 2,
                            ReleaseDate = new DateTime(2009, 1, 1, 0, 0, 0, DateTimeKind.Utc)

                        },
                         new Movie()//4
                         {
                            Name = "El Hassa El Sabaa",
                            Description = "Yehia (El-Fishawy) is a poor youth obsessed with kung fu, dreaming of becoming Egypt’s champion. Frustrated that kung fu has no future in Egypt, he challenges the world champion to regain honor. During his journey he encounters a mystical fortune-teller (Rania Kurdi) who claims he must unlock the “seventh sense” to succeed. The film follows Yehia’s comic struggles as he pursues martial-arts glory",
                            ImageURL = "https://i1.sndcdn.com/artworks-000107784931-lvueua-t500x500.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=a4A46LfSH4k",
                            MovieCategory = MovieCategory.Drama,
                            ProducerId = 3,
                            ReleaseDate = new DateTime(2005, 1, 1, 0, 0, 0, DateTimeKind.Utc)

                         },
                          new Movie()//5
                         {
                            Name = "Ayiz Haqi",
                            Description = "A down-to-earth, struggling taxi driver (Ramzi) discovers, by sheer chance, that his country's constitution grants him a share in the nation's entire public property. He proceeds to collecting power-of-attorney documents from over 50% of the population in order to literally sell out the country so that he could get married.",
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMDgxOTY4NzgtMDBhNS00MGNiLWFhYzgtYzUyYzkzOTgzZWNmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=G_MCx1yteX8",
                            MovieCategory = MovieCategory.Drama,
                            ProducerId = 4,
                            ReleaseDate = new DateTime(2008, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                         },
                           new Movie()//6
                         {
                            Name = "Zarf Tareq",
                            Description = "A careless telecom employee, Tarek (Helmy), is assigned by his boss Fadi (El-Sawy) to investigate a woman named Sara (Nour). Tarek finds Sara and falls in love with her, delaying his report to Fadi. Fadi, who also loves Sara, mistakenly believes Sara is the person he’s searching for and tries to sabotage Tarek’s romance.",
                            ImageURL = "https://media0078.elcinema.com/uploads/_315x420_18f0d7ee0bff8413a22832ef53ddcb7740b452efa1f1fb2a9b59230385164305.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=8937ZgC0FcY",
                            MovieCategory = MovieCategory.Comedy,
                            ProducerId = 5,
                            ReleaseDate = new DateTime(2006, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                         },
                            new Movie()//7
                         {
                            Name = "Ratatouille",
                            Description = "A rat who can cook makes an unusual alliance with a young kitchen worker at a famous Paris restaurant.",
                            ImageURL = "https://i.pinimg.com/736x/62/ea/5a/62ea5ab2601b52a64158fd03516b3004.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=NgsQ8mVkN8w&pp=0gcJCdgAo7VqN5tD",
                            MovieCategory = MovieCategory.Cartoon,
                            ProducerId = 8,
                            ReleaseDate = new DateTime(2007, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                         },
                            new Movie()//8
                         {
                            Name = "Brave",
                            Description = "Determined to make her own path in life, Princess Merida defies a custom that brings chaos to her kingdom. Granted one wish, Merida must rely on her bravery and her archery skills to undo a beastly curse.",
                            ImageURL = "https://images5.alphacoders.com/118/thumb-1920-1188770.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=TEHWDA_6e3M",
                            MovieCategory = MovieCategory.Cartoon,
                            ProducerId = 7,
                            ReleaseDate = new DateTime(2012, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                         }
                            ,
                            new Movie()//9
                         {
                            Name = "Home Alone 2",
                            Description = "Kevin is separated from his family again when he accidentally boards a flight to New York City during a Christmas trip to Miami. However he crosses paths with the same burglars, who now plan to rob a toy store on Christmas eve.",
                            ImageURL = "https://i.pinimg.com/736x/2b/a8/f8/2ba8f8d37292591e864fb56eb3c365b2.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=5h9VDUNtoto&pp=0gcJCdgAo7VqN5tD",
                            MovieCategory = MovieCategory.Cartoon,
                            ProducerId = 9,
                            ReleaseDate = new DateTime(1992, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                         },
                            new Movie()//10
                         {
                            Name = "The Karate Kid",
                            Description = "Work causes a single mother to move to China with her young son; in his new home, the 12-year-old boy embraces Kung Fu, taught to him by a master.",
                            ImageURL = "https://i.pinimg.com/736x/88/18/d6/8818d62260e8bc9dfafb1e6422aa9ce2.jpg",
                            TrailerURL = "https://www.imdb.com/video/vi1258882073/?playlistId=tt1155076&ref_=tt_ov_pr_ov_vi",
                            MovieCategory = MovieCategory.Drama,
                            ProducerId = 10,
                            ReleaseDate = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                         }
                            ,
                            new Movie()//11
                         {
                            Name = "Harry Potter and the Philosopher's Stone",
                            Description = "An orphaned boy enrolls in a school of wizardry, where he learns the truth about himself, his family and the terrible evil that haunts the magical world.",
                            ImageURL = "https://i.pinimg.com/736x/a4/65/e1/a465e141b024ecc746b4d507f01e4467.jpg",
                            TrailerURL = "https://www.youtube.com/watch?v=6T45PEo55Po&pp=0gcJCdgAo7VqN5tD",
                            MovieCategory = MovieCategory.Cartoon,
                            ProducerId = 11,
                            ReleaseDate = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc)

                         },
                            new Movie() //12
                            {
                                Name="Cruella",
                                Description="Estella is a young and clever grifter who's determined to make a name for herself in the fashion world. She soon meets a pair of thieves who appreciate her appetite for mischief, and together they build a life for themselves on the streets of London. However, when Estella befriends fashion legend Baroness von Hellman, she embraces her wicked side to become the raucous and revenge-bent Cruella.",
                                ImageURL="https://i.pinimg.com/736x/64/8d/4b/648d4b921acf97f7377cfe7dfd76dd09.jpg",
                                TrailerURL="https://www.youtube.com/watch?v=gmRKv7n2If8",
                                MovieCategory= MovieCategory.Drama,
                                ProducerId=8,
                                ReleaseDate = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc)


                            },
                            new Movie()//13
                            {
                                Name="Elemental",
                                Description="In a city where fire, water, land, and air residents live together, a fiery young woman and a go-with-the-flow guy discover something elemental: how much they actually have in common.",
                                ImageURL="https://i.pinimg.com/736x/bb/d9/72/bbd97204e3f5ca010f91d9c6742b23b9.jpg",
                                TrailerURL="https://www.youtube.com/watch?v=hXzcyx9V0xw",
                                MovieCategory= MovieCategory.Cartoon,
                                ProducerId=7,
                               ReleaseDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)

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
                        },
                        new MovieActor()
                        {
                            ActorId = 8,
                            MovieId = 9,
                            RoleName= "Kevin"
                        },
                        new MovieActor()
                        {
                            ActorId = 9,
                            MovieId = 10,
                            RoleName= "Mr.Han"
                        }
                        ,
                        new MovieActor()
                        {
                            ActorId = 10,
                            MovieId = 10,
                            RoleName= "Dre Parker"
                        }
                        ,
                        new MovieActor()
                        {
                            ActorId = 11,
                            MovieId = 11,
                            RoleName= "Harry Potter"
                        },
                        new MovieActor()
                        {
                            ActorId= 12,
                            MovieId = 11,
                            RoleName="Hermione Granger"
                        },
                        new MovieActor()
                        {
                            ActorId= 13,
                            MovieId = 12,
                            RoleName="Cruella"
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
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

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
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

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
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
