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
                        },new Actor()//13
                        {
                            FullName = "Emma Stone",
                            Bio = "Emily Jean \"Emma\" Stone is an American actress and film producer. Her accolades include two Academy Awards, two British Academy Film Awards, and two Golden Globe Awards. In 2017, she was the world's highest-paid actress and named by Time magazine as one of the 100 most influential people in the world.",
                            ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSTjCZFA66JXAzA7DKfj2ltseAWz2NGsKV3Wptp1SY73lhlHRLCQbkC0gd-9OFxRG9lvlIZlYrbp5F6_Vl_9CLxw"
                        },
    new Actor() //14
  {
      FullName = "Leonardo DiCaprio",
      Bio = "Leonardo DiCaprio is an award-winning American actor and producer known for films such as Titanic, Inception, and The Revenant.",
      ProfilePictureURL = "https://th.bing.com/th/id/R.32a9ce6b462f0e6bc8ec9c6f5985f0b8?rik=gVLDvKkEJ7PCMg&pid=ImgRaw&r=0"
  },

  new Actor() //15
  {
      FullName = "Matthew Broderick",
      Bio = "Matthew Broderick is an American actor who voiced adult Simba in Disney's The Lion King.",
      ProfilePictureURL = "https://th.bing.com/th/id/R.c136fb2c717d1fd3aa58cdf4eb4451c3?rik=vbgzIAA72rwaqg&pid=ImgRaw&r=0"
  },

  new Actor() //16
  {
      FullName = "Christian Bale",
      Bio = "Christian Bale is an award-winning actor known for portraying Bruce Wayne/Batman in Christopher Nolan’s The Dark Knight trilogy.",
      ProfilePictureURL = "https://th.bing.com/th/id/OIP.8wIXCKrN1Bj_F1WzX-YiLwHaKR?rs=1&pid=ImgDetMain"
  },

  new Actor() //17
  {
      FullName = "Matthew McConaughey",
      Bio = "Matthew McConaughey is an American actor who played the role of Cooper in the science fiction film Interstellar.",
      ProfilePictureURL = "https://th.bing.com/th/id/R.1bd9a715ac22b0c4f259d2bccf2d1398?rik=Vj%2bLNztw5QowNQ&pid=ImgRaw&r=0"
  },

  new Actor() //18
  {
      FullName = "Idina Menzel",
      Bio = "Idina Menzel is an American actress and singer who voiced Elsa in Disney’s Frozen and performed the song 'Let It Go'.",
      ProfilePictureURL = "https://www.hawtcelebs.com/wp-content/uploads/2019/11/idina-menzel-at-frozen-2-premiere-in-london-11-17-2019-5.jpg"
},
new Actor() //19
{
    FullName = "Sam Worthington",
    Bio = "Sam Worthington is an Australian actor best known for his role as Jake Sully in James Cameron's Avatar.",
    ProfilePictureURL = "https://th.bing.com/th/id/R.50ba5bd91e06a0d01202f1be8fc5c7f7?rik=V7vA0vJXQVKpcQ&pid=ImgRaw&r=0"
},

new Actor() //20
{
    FullName = "Tom Hanks",
    Bio = "Tom Hanks is a beloved American actor who voiced Woody in the Toy Story franchise and starred in numerous acclaimed films.",
    ProfilePictureURL = "https://th.bing.com/th/id/OIP.buuhBhTejMMZSBtbvxwpzwHaLH?rs=1&pid=ImgDetMain"
},

new Actor() //21
{
    FullName = "Russell Crowe",
    Bio = "Russell Crowe is an Academy Award-winning actor known for his powerful performance in Gladiator and many other dramatic roles.",
    ProfilePictureURL = "https://th.bing.com/th/id/R.9ed90ff7e11b169126e558b9fca20320?rik=xbyTZFQ0TGCbKQ&pid=ImgRaw&r=0"
},

new Actor() //22
{
    FullName = "Anthony Gonzalez",
    Bio = "Anthony Gonzalez is a young actor who voiced Miguel in Pixar’s Coco, bringing the character to life with charm and talent.",
    ProfilePictureURL = "https://th.bing.com/th/id/OIP.C9W_RP3VmEtSvNpsjqCD-gHaLG?rs=1&pid=ImgDetMain"
},

new Actor() //23
{
    FullName = "Keanu Reeves",
    Bio = "Keanu Reeves is a Canadian actor known for his roles in The Matrix, John Wick, and Speed, praised for both action and emotional depth.",
    ProfilePictureURL = "https://th.bing.com/th/id/OIP.lFDmnNfJ8e6VuVFWJwrSzgHaLH?rs=1&pid=ImgDetMain"
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
                             },new Producer() //12
 {
     FullName = "Emma Thomas",
     Bio = "Emma Thomas is a British film producer best known for producing the films directed by her husband, Christopher Nolan, including Inception, Interstellar, and the Dark Knight trilogy.",
     ProfilePictureURL = "https://variety.com/wp-content/uploads/2024/01/Emma-Thomas-Variety-Awards-Season-Extra-Edition.jpg?w=1200&h=1500&crop=1"
 },

 new Producer() //13
 {
     FullName = "Don Hahn",
     Bio = "Don Hahn is an American film producer who produced several successful Disney films including Beauty and the Beast and The Lion King.",
     ProfilePictureURL = "https://th.bing.com/th/id/R.b6bb7517e9f291783da48f6f6e9db1a9?rik=RmMfTNRfbkWtFA&pid=ImgRaw&r=0"
 },

 new Producer() //14
 {
     FullName = "Charles Roven",
     Bio = "Charles Roven is a Hollywood film producer known for producing The Dark Knight trilogy, Man of Steel, and other DC Universe films.",
     ProfilePictureURL = "https://th.bing.com/th/id/OIP.Wjc4MHjW07ZTkLKRmKCobgHaIy?rs=1&pid=ImgDetMain"
 },

 new Producer() //15
 {
     FullName = "Christopher Nolan",
     Bio = "Christopher Nolan is a British-American filmmaker known for his complex storytelling and groundbreaking visuals in films like Inception, Interstellar, and Tenet.",
     ProfilePictureURL = "https://th.bing.com/th/id/OIP.61lt8eMBtqUiFDop0HH4BQHaE8?rs=1&pid=ImgDetMain"
 },

 new Producer() //16
 {
     FullName = "Peter Del Vecho",
     Bio = "Peter Del Vecho is an American film producer at Walt Disney Animation Studios, known for producing Frozen and Frozen II.",
     ProfilePictureURL = "https://th.bing.com/th/id/R.6bcd71f902e222438721a91e925811e9?rik=ugiR6wZ%2fKstjrQ&riu=http%3a%2f%2fvignette4.wikia.nocookie.net%2fdisney%2fimages%2ff%2ff7%2fPeter_Del_Vecho.jpg%2frevision%2flatest%3fcb%3d20151210174134&ehk=fzLh0eF6UqZ18PyI6rc57Y52n1Fx%2f6vFW3h5RWayssA%3d&risl=&pid=ImgRaw&r=0"
},
new Producer() //17
{
    FullName = "James Cameron",
    Bio = "James Cameron is an acclaimed filmmaker known for directing and producing groundbreaking films like Titanic, Avatar, and Terminator 2.",
    ProfilePictureURL = "https://th.bing.com/th/id/R.e35a3f70e9d70dbf7f6db1c4cf3426fc?rik=GO8bFgNdDr0cOw&pid=ImgRaw&r=0"
},

new Producer() //18
{
    FullName = "Ralph Guggenheim",
    Bio = "Ralph Guggenheim is an American film producer and one of the original producers at Pixar. He worked on the landmark animated feature Toy Story.",
    ProfilePictureURL = "https://vignette.wikia.nocookie.net/pixar/images/f/f7/Ralph_Guggenheim.jpg/revision/latest?cb=20130816162650"
},

new Producer() //19
{
    FullName = "Douglas Wick",
    Bio = "Douglas Wick is a film producer known for producing Gladiator, the Academy Award-winning epic directed by Ridley Scott.",
    ProfilePictureURL = "https://www.filmindependent.org/wp-content/uploads/2020/10/Douglas-Wick-2020_600x600.jpg"
},

new Producer() //20
{
    FullName = "Darla K. Anderson",
    Bio = "Darla K. Anderson is an award-winning producer at Pixar known for her work on Coco, Toy Story 3, and Monsters, Inc.",
    ProfilePictureURL = "https://th.bing.com/th/id/OIP.nFZVOo4cE-yv5ZNH3Swh4QHaE8?rs=1&pid=ImgDetMain"
},

new Producer() //21
{
    FullName = "Joel Silver",
    Bio = "Joel Silver is a prolific American film producer known for The Matrix trilogy, Die Hard, and Lethal Weapon series.",
    ProfilePictureURL = "https://th.bing.com/th/id/OIP.KgWS_A9JAFjc2HvBz4zHYwHaFj?rs=1&pid=ImgDetMain"
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

                            },new Movie() //14
{
    Name = "Inception",
    Description = "A thief who steals corporate secrets through dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
    ImageURL = "https://th.bing.com/th/id/OIP.ps02Cq1ZLtzBEPPpSVttKgHaLH?rs=1&pid=ImgDetMain",
    TrailerURL = "https://www.youtube.com/watch?v=YoHD9XEInc0",
    MovieCategory = MovieCategory.Action,
    ProducerId = 12,
    ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //15
{
    Name = "The Lion King",
    Description = "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself.",
    ImageURL = "https://th.bing.com/th/id/R.68423a589db68b81d8011149d4e2f216?rik=htf79yDmcv%2f1Bg&pid=ImgRaw&r=0",
    TrailerURL = "https://www.youtube.com/watch?v=7TavVZMewpY",
    MovieCategory = MovieCategory.Cartoon,
    ProducerId = 13,
    ReleaseDate = new DateTime(1994, 6, 24, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //16
{
    Name = "The Dark Knight",
    Description = "Batman faces the Joker, a criminal mastermind who plunges Gotham City into anarchy.",
    ImageURL = "https://th.bing.com/th/id/R.7858584e0e540252618d7bfb1ef46804?rik=pde7ZIE3QaH7Ig&riu=http%3a%2f%2fhost.trivialbeing.org%2fup%2ftdk-may17-joker-poster-large.jpg&ehk=g8dnVbBCb1VT%2fO9yUlm0aTB9RfEQ80PTB1aYTenHrKs%3d&risl=&pid=ImgRaw&r=0",
    TrailerURL = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
    MovieCategory = MovieCategory.Action,
    ProducerId = 14,
    ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //17
{
    Name = "Interstellar",
    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
    ImageURL = "https://m.media-amazon.com/images/I/91kFYg4fX3L.AC_SL1500.jpg",
    TrailerURL = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
    MovieCategory = MovieCategory.ScienceFiction,
    ProducerId = 15,
    ReleaseDate = new DateTime(2014, 11, 7, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //18
{
    Name = "Frozen",
    Description = "When the newly crowned Queen Elsa accidentally uses her power to turn things into ice, her sister Anna teams up with a mountain man to change the weather condition.",
    ImageURL = "https://th.bing.com/th/id/OIP.wmyQyDloEy1tI3uCLGiTswHaKb?rs=1&pid=ImgDetMain",
    TrailerURL = "https://www.youtube.com/watch?v=TbQm5doF_Uc",
    MovieCategory = MovieCategory.Cartoon,
    ProducerId = 16,
    ReleaseDate = new DateTime(2013, 11, 27, 0, 0, 0, DateTimeKind.Utc)
},
new Movie() //19
{
    Name = "Avatar",
    Description = "A paraplegic Marine is dispatched to the moon Pandora on a unique mission but becomes torn between following orders and protecting an alien civilization.",
    ImageURL = "https://m.media-amazon.com/images/I/41kTVLeW1CL._AC_SY445_.jpg",
    TrailerURL = "https://www.youtube.com/watch?v=5PSNL1qE6VY",
    MovieCategory = MovieCategory.ScienceFiction,
    ProducerId = 17,
    ReleaseDate = new DateTime(2009, 12, 18, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //20
{
    Name = "Toy Story",
    Description = "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.",
    ImageURL = "https://m.media-amazon.com/images/I/51K8ouYrHeL._AC_SY445_.jpg",
    TrailerURL = "https://www.youtube.com/watch?v=4YKv__f7KzE",
    MovieCategory = MovieCategory.Cartoon,
    ProducerId = 18,
    ReleaseDate = new DateTime(1995, 11, 22, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //21
{
    Name = "Gladiator",
    Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
    ImageURL = "https://image.tmdb.org/t/p/original/ehGpN04mLJIrSnxcZBMvHeG0eDc.jpg",
    TrailerURL = "https://www.youtube.com/watch?v=owK1qxDselE",
    MovieCategory = MovieCategory.Action,
    ProducerId = 19,
    ReleaseDate = new DateTime(2000, 5, 5, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //22
{
    Name = "Coco",
    Description = "Aspiring musician Miguel, confronted with his family's ancestral ban on music, enters the Land of the Dead to find his great-great-grandfather.",
    ImageURL = "https://image.tmdb.org/t/p/original/fqZEc92MAFy5mR6aSMRDx1QN73N.jpg",
    TrailerURL = "https://www.youtube.com/watch?v=Ga6RYejo6Hk",
    MovieCategory = MovieCategory.Cartoon,
    ProducerId = 20,
    ReleaseDate = new DateTime(2017, 11, 22, 0, 0, 0, DateTimeKind.Utc)
},

new Movie() //23
{
    Name = "The Matrix",
    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
    ImageURL = "https://m.media-amazon.com/images/I/51EG732BV3L._AC_SY445_.jpg",
    TrailerURL = "https://www.youtube.com/watch?v=vKQi3bBA1y8",
    MovieCategory = MovieCategory.ScienceFiction,
    ProducerId = 21,
    ReleaseDate = new DateTime(1999, 3, 31, 0, 0, 0, DateTimeKind.Utc)
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
                        },new MovieActor()
{
    ActorId= 14,
    MovieId = 14,
    RoleName="Leonardo DiCaprio"
},

  new MovieActor()
{
    ActorId= 15,
    MovieId = 15,
    RoleName="Matthew Broderick"
},

   new MovieActor()
{
    ActorId= 16,
    MovieId = 16,
    RoleName="Christian Bale"
},
    new MovieActor()
{
    ActorId= 17,
    MovieId = 17,
    RoleName="Matthew McConaughey"
},

     new MovieActor()
{
    ActorId= 18,
    MovieId = 18,
    RoleName="Idina Menzel"
}






                    });
                    context.SaveChanges();
                }

                if (!context.Showtimes.Any())
                {
                    var movies = context.Movies.ToList();
                    var cinemaIds = new List<int> { 1, 2, 3, 4 };

                    foreach (var movie in movies)
                    {
                        foreach (var cinemaId in cinemaIds)
                        {
                            var showtime = new Showtime
                            {
                                Movie_Id = movie.Id,
                                Cinema_Id = cinemaId,
                                Date = new DateTime(2025, 6, (movie.Id + cinemaId) % 28 + 1)
                            };

                            context.Showtimes.Add(showtime);
                            context.SaveChanges(); // get showtime.Id

                            // Add timings
                            var timings = new List<Timing>
            {
                new Timing { showtime_id = showtime.Showtime_Id, StartTime = new TimeSpan(4, 0, 0), Price = 100 + movie.Id + cinemaId },
                new Timing { showtime_id = showtime.Showtime_Id, StartTime = new TimeSpan(6, 0, 0), Price = 110 + movie.Id + cinemaId },
                new Timing { showtime_id = showtime.Showtime_Id, StartTime = new TimeSpan(8, 0, 0), Price = 120 + movie.Id + cinemaId },
                new Timing { showtime_id = showtime.Showtime_Id, StartTime = new TimeSpan(10, 0, 0), Price = 130 + movie.Id + cinemaId }
            };

                            context.Timings.AddRange(timings);
                            context.SaveChanges(); // get timings' Ids

                            // Generate seats for each timing
                            foreach (var timing in timings)
                            {
                                var tickets = new List<Ticket>();

                                for (int row = 1; row <= 10; row++)
                                {
                                    for (int seat = 1; seat <= 15; seat++)
                                    {
                                        tickets.Add(new Ticket
                                        {
                                            Timing_Id = timing.Id,
                                            RowNumber = row,
                                            SeatNumber = seat,
                                            SeatType = (row <= 2) ? "Premium" : "Regular",
                                            IsBooked = false
                                        });
                                    }
                                }

                                context.Tickets.AddRange(tickets);
                            }

                            context.SaveChanges(); // save all tickets at once after adding
                        }
                    }
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
