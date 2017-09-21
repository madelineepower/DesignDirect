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
                        Name = "Eclectic"
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
                            RoomId = 1,
                            StyleId = 8,
                            Source="https://st.hzcdn.com/fimgs/6041dff40f5a8418_2289-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 8,
                            Source="https://st.hzcdn.com/fimgs/e9c178400fd9c2aa_0858-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 8,
                            Source="https://st.hzcdn.com/fimgs/b751dc9d01145934_6519-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 7,
                            Source ="https://st.hzcdn.com/fimgs/cd21fa7f0f0f9b17_1255-w500-h666-b0-p0--.jpg" 
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 7,
                            Source ="https://st.hzcdn.com/fimgs/2091bc5900802a8c_0467-w500-h400-b0-p0--.jpg" 
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 7,
                            Source ="https://st.hzcdn.com/fimgs/2131db890e4bf294_1569-w500-h400-b0-p0--.jpg" 
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 6,
                            Source ="https://st.hzcdn.com/fimgs/e4c1a35805025f50_9663-w500-h666-b0-p0--.jpg"
                            },
                        
                        new Image {
                            RoomId = 1,
                            StyleId = 6,
                            Source ="https://st.hzcdn.com/fimgs/2e31eeec053e8c44_5611-w500-h666-b0-p0--.jpg"
                            },
                        
                        new Image {
                            RoomId = 1,
                            StyleId = 6,
                            Source ="https://st.hzcdn.com/fimgs/6bf1bcc0056f5aff_2705-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/be4171cb03f52cb5_8185-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/13d12bff0e9613f6_1529-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/efe1c44b026197c8_8805-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/1db151eb0134b38c_9820-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/02b180720ecd3b4c_9984-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/1d21e9dd0ff5c6a8_0787-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 3,
                            Source= "https://st.hzcdn.com/fimgs/d1a176a506d5b7a1_4985-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 3,
                            Source= "https://st.hzcdn.com/fimgs/8ad1928d0ed6a9f2_1371-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 3,
                            Source= "https://st.hzcdn.com/fimgs/b9d123f90fc6d9c6_0861-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/eb0193290fdbbc09_0827-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/dcc10c9e0b87465a_2047-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/1011d4ef0af3522c_2063-w500-h666-b0-p0--.jpg"
                            },    
                        new Image {
                            RoomId = 1,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/68615d0b013fb3f3_9750-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/2221f4c20b9e8a24_2052-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 1,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/eef152c9030b6056_6094-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 1,
                            Source="https://st.hzcdn.com/fimgs/0d6142f301edaeef_0749-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 1,
                            Source="https://st.hzcdn.com/fimgs/8a817d680d23fb9a_3678-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 1,
                            Source="https://st.hzcdn.com/fimgs/c2619ba5033a1584_5196-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/b441c7b100f58b28_4759-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/6f71d2870ef0f88f_7117-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/34417d120d24412e_3678-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/01b1fd72037179fe_0148-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/cd81560404beac83_8981-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/4441fa3b01c0a9fc_9177-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/dd61d4b900aaf318_1079-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/f051d14e0356b05b_2769-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/8d612f31009d2e97_9662-w500-h500-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/85b1a6590155df8b_8025-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/14610470019fa715_2144-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/153130230048bdb0_3009-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/70e1c63b01f9d426_3785-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/04e1059c0140d76c_9769-w500-h500-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/ae41dba1003fa1b7_3035-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 7,
                            Source ="https://st.hzcdn.com/fimgs/01b1b6540f3023c4_3315-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 7,
                            Source ="https://st.hzcdn.com/fimgs/6fb1b77900e713ab_7924-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 7,
                            Source ="https://st.hzcdn.com/fimgs/c7c198a600410637_3000-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 8,
                            Source ="https://st.hzcdn.com/fimgs/7ca107a40fccc38c_3129-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 8,
                            Source ="https://st.hzcdn.com/fimgs/f9e123d70eb07f79_9291-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 2,
                            StyleId = 8,
                            Source ="https://st.hzcdn.com/fimgs/42c1e3a40415c27d_0731-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/1ab16f760122f5ad_2090-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/08c1d1ff0249f00b_4626-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/bf01bb0200477e56_1216-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId= 3,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/95219d020e272b0a_2390-w500-h400-b0-p0--.jpg" 
                            },

                        new Image {
                            RoomId= 3,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/3d515f960f3b29d9_0800-w500-h666-b0-p0--.jpg" 
                            },

                        new Image {
                            RoomId= 3,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/c5e1e1c40efb42b7_1437-w500-h400-b0-p0--.jpg" 
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/e231e0960447b138_4993-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/2fa1235b0e062e91_2470-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/1011976803cd3c67_2135-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/9a71cf17027b8a8d_9614-w500-h666-b0-p0--.jpg"
                        },
                        new Image {
                            RoomId = 3,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/9ad1d9a90f6891d6_0215-w500-h666-b0-p0--.jpg"
                        },
                        new Image {
                            RoomId = 3,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/d4517c9800907829_5760-w500-h666-b0-p0--.jpg"
                        }, 
                        new Image {
                            RoomId = 3,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/7941f8d00eb00ae2_6694-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/8d316e140fcee61d_8920-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/63414a8503b05eb9_3582-w500-h666-b0-p0--.jpg"
                            }, 
                        new Image {
                            RoomId = 3,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/5cd195de00eedebf_3796-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/ac41104402442df3_1938-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/238158120e95fd90_1986-w500-h666-b0-p0--.jpg"
                            },  
                        new Image {
                            RoomId = 3,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/bc51fe540d2b5645_3227-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/0e611eb3009479e4_5638-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/64e1308e0f309000_7612-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/3741f69c021e3443_3485-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/50a13b3b0fa1ee16_9447-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 3,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/0381e9f000e59711_4083-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/67f14054024c5b8c_1283-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/4bf10cb801f992ef_3048-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/5761e8130c924c0a_9980-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/d291b0d802716d8f_5519-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/f6c1e19d02dd5847_2777-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/9351dd1300226ca7_1944-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/56717001044a87a2_0955-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/7851611700608718_1918-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/2bf15e6606034a4c_7270-w500-h500-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/1b81b3dd0f6a408d_2190-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/34e1f6170102a96e_1683-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/af01732a0d23a798_2297-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 5,
                            Source ="https://st.hzcdn.com/fimgs/4501457f0f2c2bdc_6682-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 5,
                            Source ="https://st.hzcdn.com/fimgs/75419ab800412983_1936-w500-h500-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 5,
                            Source ="https://st.hzcdn.com/fimgs/95514da20f90b7bb_3568-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 6,
                            Source ="https://st.hzcdn.com/fimgs/c5b1e72905345c91_2411-w500-h500-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 6,
                            Source ="https://st.hzcdn.com/fimgs/bab1c3de0f4d37d8_2095-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 6,
                            Source ="https://st.hzcdn.com/fimgs/97f1db9005ca0d6c_3199-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/f711eb9b073a0e84_5148-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/d6b12a320ea84ab5_3684-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/7701c62f00d23eac_8341-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/3341772f014fd3c1_5976-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/cc01e7da0166de7a_1566-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 4,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/552132e70f79e1b8_7690-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/25b110c00ce1773c_6825-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/4101ef4d00b7e017_6047-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/8cd171510f73efc6_4287-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/37e140b40e299c80_5950-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/70d1240c0e273043_5993-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/2351e3e203986024_9838-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/9fa11898016ebcbe_0445-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/7a4148a1036f77fb_9147-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/05115d700588c809_6384-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/712124f80fe8cfe4_5062-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/a45109870f1da680_7462-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/d8f16e770f678d39_4448-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/fc817f9c0b3fb7df_7196-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/3aa1ee6c01a3e7ad_4699-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/cac1e88602619762_1887-w500-h400-b0-p0--.jpg"
                            },                        
                        new Image {
                            RoomId = 5,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/d0414a2b0f9ef486_3824-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/4e010882006c9ba7_9037-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/d2810f3a0fc93912_3344-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/0941d4870f42cd9d_4796-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/1cc152a40053833b_9793-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/82214a740c9222bc_6928-w500-h666-b0-p0--.jpg"
                        },
                        new Image {
                            RoomId = 5,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/54319aa90ed6a62f_5786-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/4571c8f501f753af_6040-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 5,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/fbe1df3302042a81_5393-w500-h666-b0-p0--.jpg"
                            }, 
                        new Image {
                            RoomId = 6,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/b72104e002b1b6e6_0339-w500-h666-b0-p0--.jpg"
                            }, 
                        new Image {
                            RoomId = 6,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/76818011007ec744_4432-w500-h666-b0-p0--.jpg"
                            }, 
                        new Image {
                            RoomId = 6,
                            StyleId = 1,
                            Source = "https://st.hzcdn.com/fimgs/2ed1b3ef0d012f37_7607-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/7d0195f80e78c98e_8185-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/9bc13d5c0214dbf7_0661-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 2,
                            Source = "https://st.hzcdn.com/fimgs/1c11373d0011ba35_6922-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/d661c8930fdb4f62_8644-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/2001f0150fb2710d_9842-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 3,
                            Source = "https://st.hzcdn.com/fimgs/7da121db003fb794_5467-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/58e1ba5a0eb2e255_7996-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/6aa17be703a2dac1_9497-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 4,
                            Source = "https://st.hzcdn.com/fimgs/8c51df5a0eb2e24d_7996-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/0af11db600f70d18_8060-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/69c10b3b0f2c2d1f_3073-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 5,
                            Source = "https://st.hzcdn.com/fimgs/f77164390fba94ed_9568-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/240174f90ea8049e_8014-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/f3c17a2100b856b3_7564-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 6,
                            Source = "https://st.hzcdn.com/fimgs/48b120f20f707567_9911-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/7251878b0d3e26d8_7261-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/16019b400c23f839_9322-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 7,
                            Source = "https://st.hzcdn.com/fimgs/f93127fc0c23f832_9322-w500-h400-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/e08166f10265c084_3427-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/5b5165fd049224e3_9387-w500-h666-b0-p0--.jpg"
                            },
                        new Image {
                            RoomId = 6,
                            StyleId = 8,
                            Source = "https://st.hzcdn.com/fimgs/79119b310e9df957_4835-w500-h666-b0-p0--.jpg"
                            }                                                                                                              
                );

                context.SaveChanges();
            }
        }  
    }
}