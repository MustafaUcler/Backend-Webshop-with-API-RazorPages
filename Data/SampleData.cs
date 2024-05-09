using BackendApp1.Models;

namespace BackendApp1.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {


            if (database.Products.Count() >= 30)
            {
                return;
            }
      
        // If there are no fake accounts, add some.
        string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will"
                });
            }


         
    

            database.Products.Add(new Product
            {
                Name = "Leksak1",
                ImageUrl = $"/images/1.jpg",
                Price = 1,
                Category = "Leksak1",
                Description = "Bla1"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak2",
                ImageUrl = $"/images/2.jpg",
                Price = 2,
                Category = "Leksak1",
                Description = "Bla2"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak3",
                ImageUrl = $"/images/3.jpg",
                Price = 3,
                Category = "Leksak1",
                Description = "Bla3"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak4",
                ImageUrl = $"/images/4.jpg",
                Price = 4,
                Category = "Leksak1",
                Description = "Bla4"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak5",
                ImageUrl = $"/images/5.jpg",
                Price = 5,
                Category = "Leksak1",
                Description = "Bla5"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak6",
                ImageUrl = $"/images/6.jpg",
                Price = 6,
                Category = "Leksak1",
                Description = "Bla6"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak7",
                ImageUrl = $"/images/7.jpg",
                Price = 7,
                Category = "Leksak1",
                Description = "Bla7"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak8",
                ImageUrl = $"/images/8.jpg",
                Price = 8,
                Category = "Leksak1",
                Description = "Bla8"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak9",
                ImageUrl = $"/images/9.jpg",
                Price = 9,
                Category = "Leksak1",
                Description = "Bla9"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak10",
                ImageUrl = $"/images/10.jpg",
                Price = 10,
                Category = "Leksak1",
                Description = "Bla10"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak11",
                ImageUrl = $"/images/11.jpg",
                Price = 11,
                Category = "Leksak2",
                Description = "Bla11"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak12",
                ImageUrl = $"/images/12.jpg",
                Price = 12,
                Category = "Leksak2",
                Description = "Bla12"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak13",
                ImageUrl = $"/images/13.jpg",
                Price = 13,
                Category = "Leksak2",
                Description = "Bla13"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak14",
                ImageUrl = $"/images/14.jpg",
                Price = 14,
                Category = "Leksak2",
                Description = "Bla14"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak15",
                ImageUrl = $"/images/15.jpg",
                Price = 15,
                Category = "Leksak2",
                Description = "Bla15"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak16",
                ImageUrl = $"/images/16.jpg",
                Price = 16,
                Category = "Leksak2",
                Description = "Bla16"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak17",
                ImageUrl = $"/images/17.jpg",
                Price = 17,
                Category = "Leksak2",
                Description = "Bla17"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak18",
                ImageUrl = $"/images/18.jpg",
                Price = 18,
                Category = "Leksak2",
                Description = "Bla18"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak19",
                ImageUrl = $"/images/19.jpg",
                Price = 19,
                Category = "Leksak2",
                Description = "Bla19"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak20",
                ImageUrl = $"/images/20.jpg",
                Price = 20,
                Category = "Leksak2",
                Description = "Bla20"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak21",
                ImageUrl = $"/images/21.jpg",
                Price = 21,
                Category = "Leksak3",
                Description = "Bla21"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak22",
                ImageUrl = $"/images/22.jpg",
                Price = 22,
                Category = "Leksak3",
                Description = "Bla22"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak23",
                ImageUrl = $"/images/23.jpg",
                Price = 23,
                Category = "Leksak3",
                Description = "Bla23"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak24",
                ImageUrl = $"/images/24.jpg",
                Price = 24,
                Category = "Leksak3",
                Description = "Bla24"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak25",
                ImageUrl = $"/images/25.jpg",
                Price = 25,
                Category = "Leksak3",
                Description = "Bla25"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak26",
                ImageUrl = $"/images/26.jpg",
                Price = 26,
                Category = "Leksak3",
                Description = "Bla26"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak27",
                ImageUrl = $"/images/27.jpg",
                Price = 27,
                Category = "Leksak3",
                Description = "Bla27"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak28",
                ImageUrl = $"/images/28.jpg",
                Price = 28,
                Category = "Leksak3",
                Description = "Bla28"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak29",
                ImageUrl = $"/images/29.jpg",
                Price = 29,
                Category = "Leksak3",
                Description = "Bla29"
            });

            database.Products.Add(new Product
            {
                Name = "Leksak30",
                ImageUrl = $"/images/30.jpg",
                Price = 30,
                Category = "Leksak3",
                Description = "Bla30"
            });


            database.SaveChanges();

        }
    }
}


