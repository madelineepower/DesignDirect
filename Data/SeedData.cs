using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using DesignDirect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DesignDirect.Data
{
    public class SeedData
    {
      public async static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext (
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Room.Any())
                {
                    return;   // DB has been seeded
                }

               var userStore = new UserStore<ApplicationUser>(context);

                var userList = new ApplicationUser[]
                {
                    new ApplicationUser {
                        UserName = "madelineepower@gmail.com",
                        NormalizedUserName = "madelineepower@gmail.com",
                        Email = "madelineepower@gmail.com",
                        NormalizedEmail = "madelineepower@gmail.com",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                        ZipCode = "37209",
                        FirstName = "Madeline",
                        LastName = "Power"
                    },
                    new ApplicationUser
                    {
                        UserName = "c@c.com",
                        NormalizedUserName = "C@C.COM",
                        Email = "c@c.com",
                        NormalizedEmail = "C@C.com",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                        ZipCode = "09182",
                        FirstName = "Tinker",
                        LastName = "Bell"
                    }
                };

                foreach (ApplicationUser user in userList)
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user, "password");
                    user.PasswordHash = hashed;
                    await userStore.CreateAsync(user);
                }
                await context.SaveChangesAsync();

                context.Room.AddRange(
                     new Room
                     {
                         Name = "Kitchen",
                     },
                     new Room
                     {
                         Name = "Bathroom",
                     },
                     new Room
                     {
                         Name = "Bedroom",
                     },
                     new Room
                     {
                         Name = "Outdoor",
                     },
                     new Room
                     {
                         Name = "Laundry",
                     },
                     new Room
                     {
                         Name = "Office",
                     },
                     new Room
                     {
                         Name = "Dining",
                     },
                     new Room
                     {
                         Name = "Living",
                     }
                );

                await context.SaveChangesAsync();
                context.Tag.AddRange(
                    new Tag {
                        Name = "Cabinets"
                    },
                    new Tag {
                        Name = "Kitchen Design"
                    },
                    new Tag {
                        Name = "Bathroom Design"
                    },
                    new Tag {
                        Name = "Tile"
                    },
                    new Tag {
                        Name = "Paint"
                    },
                    new Tag {
                        Name = "Hardwood Floors"
                    },
                    new Tag {
                        Name = "Furniture"
                    },
                    new Tag {
                        Name = "Living Room Design"
                    },
                    new Tag {
                        Name = "Landscaping"
                    },
                    new Tag {
                        Name = "Architecture"
                    },
                    new Tag {
                        Name = "Decor"
                    },
                    new Tag {
                        Name = "Deck"
                    }
                );

                await context.SaveChangesAsync();
                
                context.Style.AddRange(
                    new Style {
                        Name = "Contemporary"
                    },
                     new Style {
                        Name = "Traditional"
                    },
                     new Style {
                        Name = "Farmhouse"
                    },
                     new Style {
                        Name = "Rustic"
                    },
                     new Style {
                        Name = "Industrial"
                    },
                     new Style {
                        Name = "Beach Style"
                    },
                     new Style {
                        Name = "Midcentury"
                    },
                     new Style {
                        Name = "Ecletic"
                    }
                );

                await context.SaveChangesAsync();
                
                context.Service.AddRange(
                    new Service {
                        Name = "General Contractor"
                    },
                     new Service {
                        Name = "Interior Design"
                    },
                     new Service {
                        Name = "Architect"
                    },
                     new Service {
                        Name = "Landscape Architect"
                    },
                     new Service {
                        Name = "Cabinets & Cabinetry"
                    },
                     new Service {
                        Name = "Painter"
                    },
                     new Service {
                        Name = "Electrician"
                    },
                     new Service {
                        Name = "Lighting"
                    },
                    new Service {
                        Name = "Deck & Patio"
                    },
                    new Service {
                        Name = "Roofing & Gutters"
                    },
                    new Service {
                        Name = "Movers"
                    },
                    new Service {
                        Name = "Pest Control"
                    },
                    new Service {
                        Name = "Kitchen & Bath Design"
                    }
                );
                await context.SaveChangesAsync();
                context.Image.AddRange(
                    new Image {
                        Description = "",
                        RoomId = 1,
                        StyleId = 2,
                        Source="https://st.hzcdn.com/fimgs/2391ae73002aa211_6149-w133-h133-b0-p0--.jpgSource=" 
                    },
                    new Image {
                        Description = "",
                        RoomId = 1,
                        StyleId = 2,
                        Source="https://st.hzcdn.com/fimgs/a191f34606b0cff1_4861-w133-h133-b0-p0--.jpgSource="
                         
                    },
                    new Image {
                        Description = "",
                        RoomId = 1,
                        StyleId = 2,
                        Source="https://st.hzcdn.com/fimgs/8001829c00a294bf_0351-w133-h133-b0-p0--.jpgSource="
                    },
                    new Image {
                        Description = "",
                        RoomId = 1,
                        StyleId = 2,
                         Source="https://st.hzcdn.com/fimgs/25113bd20ff8a6e8_0793-w133-h133-b0-p0--.jpgSource="
                    },

                    new Image {
                        Description = "",
                        RoomId = 1,
                        StyleId = 2,
                        Source="https://st.hzcdn.com/fimgs/fb31ca6a0eddb25c_1444-w133-h133-b0-p0--.jpgSource="
                    },

                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/519138990f4bc41f_1158-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/d3e10bcd0347f40f_3627-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/e401ef3000cce79f_0182-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/4181f4ac004a713c_7788-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/dcc10c9e0b87465a_2047-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/2811926f0cec31c2_1537-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/7d01ad9100be904d_0254-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/7f5148f20494bd77_1483-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/7ea1a6200ceaa29c_1917-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/0801da11015cf020_9661-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/1011d4ef0af3522c_2063-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/eef152c9030b6056_6094-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/eb0193290fdbbc09_0827-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/1c213c88060be5c3_1539-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/d981d9dd0023db77_6658-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/2221f4c20b9e8a24_2052-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/c7f1a7c10fd78ce7_5085-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/7791cbc70d386144_9905-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/23e1987701fab92f_9294-w133-h133-b0-p0--.jpgSource="
                        },
                    new Image {
                        Description= "",
                        RoomId = 1,
                        StyleId = 2,Source="https://st.hzcdn.com/fimgs/d431ec67060d3629_1091-w133-h133-b0-p0--.jpg"
                    },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/b441c7b100f58b28_4759-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/be81bff30db354a8_3553-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/ae2179360b57da2f_3785-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/b5f155b3063ac6fc_5228-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/b4c1f07501532c3a_8380-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/c2619ba5033a1584_5196-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/f101479702af3031_0201-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/0d6142f301edaeef_0749-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/f5b1e9e30cb73b5c_6464-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/2da1613a02e29682_5842-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/6f71d2870ef0f88f_7117-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/8a817d680d23fb9a_3678-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/13f1a6a30e14aee2_3541-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/fcc18a680283bc39_1204-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/fe919482009c58e2_0303-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/6f812ce30fd206cb_3138-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/785161ac0d4c52f2_1127-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/34417d120d24412e_3678-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/60c1dc3f046ba9f4_9057-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/01b1b6540f3023c4_3315-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/17e11d2405e4aa27_5715-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/5091e80e00a6c6ce_1237-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/71b1370f019b87e4_2588-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/0f21d67e0362b965_1596-w133-h133-b0-p0--.jpg" 
                        },
                    new Image {
                        Description = "",
                        RoomId = 2,
                        StyleId = 1,
                        Source ="https://st.hzcdn.com/fimgs/b9f1c0190f5f9367_3247-w133-h133-b0-p0--.jpg" 
                        },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/08c1d1ff0249f00b_4626-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/238158120e95fd90_1986-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/1011976803cd3c67_2135-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/50a13b3b0fa1ee16_9447-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/56811aeb0f0f6470_1319-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/c5e1e1c40efb42b7_1437-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/2fa1235b0e062e91_2470-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/6df160830e26d84c_2390-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/5841f60b0f207186_2815-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/1301e7710e15d845_2430-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/95219d020e272b0a_2390-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/5cd195de00eedebf_3796-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/ac41104402442df3_1938-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/b12130d20e27066e_5182-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/1ab16f760122f5ad_2090-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/3d515f960f3b29d9_0800-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/6a0143810175c2d1_9467-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/0fb1906503bec46d_4225-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/48e1ac9202ea93d9_7765-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/f0313aab011d4557_8344-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/8601f4b4002e8beb_7593-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/bf01bb0200477e56_1216-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/a941873e0d7414d8_2925-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/46015b350f94f9bb_9622-w133-h133-b0-p0--.jpg"
                            },
                        new Image {
                            Description = "",
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/fd1113e60106912f_3066-w133-h133-b0-p0--.jpg"
                            },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/d931c502035da8da_1090-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/67f14054024c5b8c_1283-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/45a1eca9040232d5_0232-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/5ec1ed2f0f9426e5_9885-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/02616919028505a0_7791-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/2481c6a100994b4e_3369-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/1b81b3dd0f6a408d_2190-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/0bf1db8c0f3a954d_3610-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/c16135f10278365b_6430-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/8981cae500c61a42_3344-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/ee71d44c0f0dff56_8436-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/4bf10cb801f992ef_3048-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/9351dd1300226ca7_1944-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/d291b0d802716d8f_5519-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/558173d30130d13a_3217-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/af01732a0d23a798_2297-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/5761e8130c924c0a_9980-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/b3b1890d03f23a8f_3460-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/6011a2fd0266b584_6461-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/bcf119ed013946de_1594-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/04d1fee10074a563_3446-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/6b61fd0b061e9d06_3912-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/8bb113d702492191_9040-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/7d6194b700283e75_3516-w133-h133-b0-p0--.jpg"
                                },
                            new Image {
                                Description = "",
                                RoomId = 4,
                                StyleId = 2,
                                Source = "https://st.hzcdn.com/fimgs/f6c1e19d02dd5847_2777-w133-h133-b0-p0--.jpg"
                                },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/8e2109e502b619fa_7979-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/cd41638f031b6b0d_7742-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/fa01888a0138947c_3812-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/a021f7ab0fba640e_7796-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/0071715f04f0d215_8575-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/cc713d8d012e6b9e_2400-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/36016ee30f85c3e1_6954-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/2001545b02e155f6_7735-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/fa816ec002b07de4_7501-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/f6e1ace90e36c77d_7819-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/8c21ee2e046ac483_7694-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/f391cfc6056dab96_7711-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/65217c8d03015f50_7739-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/7b0188d50267cddd_7766-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/c8a186610fe1e206_7798-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/0401dc1f02e98ae2_7736-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/ef21d3320fc67c6a_2447-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/c981a0ae012e5c7b_7778-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/b2a108d40fa7edb4_7837-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/b251e78a02f3f51d_7569-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/7d51aedb005a2d2b_7805-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/4011564700918d2f_7519-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/3291697804db6497_7700-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/05118aae0e20690a_7819-w133-h133-b0-p0--.jpg"
                        },
                    new Image {
                        Description = "",
                        RoomId = 5,
                        StyleId = 3,
                        Source = "https://st.hzcdn.com/fimgs/68f1affc0036937f_7802-w133-h133-b0-p0--.jpg"
                        }
   
                );

                context.SaveChanges();
            }
        }  
    }
}