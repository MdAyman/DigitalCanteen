using DigitalCanteen.Models.Entities;

namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DigitalCanteen.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DigitalCanteen.Data.DataContext context)
        {
         
            var userCredential = new UserCredential()
            {
                Username = "Admin",
                Password = "Admin",
                UserType = 1
            };

            var userDetail = new UserDetail()
            {
                FullName = "Mr. Admin",
                Department = "Cse",
                Email = "admin@admin.com",
                Phone = "136846341",
                DateOfBirth = DateTime.Now,
              
                Address = "fdsfsdfdsf",
            
                UserCredential = userCredential

            };
            var accountdetail  = new AccountDetail(){
            
               
               Balance = 0,
               
               //UserDetail = userDetail
            };
            var ranNo = new RandomNo()
            {
                RandomNumber = 111,
                IsCheck = false
            };



            context.UserDetails.AddOrUpdate(userDetail);
            context.AccountDetails.AddOrUpdate(accountdetail);
            context.RandomNoes.AddOrUpdate(ranNo);

        }
    }
}
