using s198599_mappe3.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models
{
    public class FaqSeedInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            IList<DbCategory> Categories = new List<DbCategory>();
            Categories.Add(new DbCategory { CategoryName = "Payment", LastModifiedAt = DateTime.Now, CreatedAt = DateTime.Now });
            Categories.Add(new DbCategory { CategoryName = "Shopping Cart", LastModifiedAt = DateTime.Now, CreatedAt = DateTime.Now });
            Categories.Add(new DbCategory { CategoryName = "My Account", LastModifiedAt = DateTime.Now, CreatedAt = DateTime.Now });

            foreach (var cat in Categories) { 
                context.Category.Add(cat);
                
            }

            context.SaveChanges();

            IList<DbQuestion> Questions = new List<DbQuestion>
            {
                new DbQuestion
                {
                    Heading = "What does the Credit Card fields mean?",
                    Body = "I do not understand which information to enter in the Payment Details. "
                        + " Where can I find this information?",
                    Answer = "On the credit card you will find 16 digits in a row. This is the Credit card number. "
                        + "Expiry Date is the 'month/year' that is located below the credit card number."
                        + "CSV code you can find on the back side of the credit card and it is located on the 'signature field'"
                        + "and it is the last 3 digits on that field.",
                    RespondEmail = "ola@online.no",
                    RelevanceScore = 5,
                    CategoryID = 1
                },
                new DbQuestion
                {
                    Heading = "Can I get a volume discount?",
                    Body = "I am planning on a large purchase and I am wondering if it is possible to get a volue discount, and how I would go about it?",
                    Answer = "It is possible to get a discount, but only on products that is labeled for volume discount. "
                            + "Loyal customers that has a lot of purchases will also get special offers sent by email on regular basis",
                    RespondEmail = "ola@online.no",
                    RelevanceScore = 1,
                    CategoryID = 1
                },
                new DbQuestion
                {
                    Heading = "Can I pay with PayPal?",
                    Body = "I am currently without a Credit card but i do have a PayPal account. Do you support PayPal?",
                    Answer = "Currently we are not supporting PayPal. This is a feature we are planning to imlement as soon as possible.",
                    RespondEmail = "ola@online.no",
                    RelevanceScore = 15,
                    CategoryID = 1
                },
                new DbQuestion
                {
                    Heading = "Edit my account",
                    Body = "When I try to edit my account it does not accept my email address. I write it like this: ola@online..no",
                    Answer = "You have an error in you email address. Remove one of the periods and try again",
                    RespondEmail = "ola@online.no",
                    RelevanceScore = 3,
                    CategoryID = 3
                },
                new DbQuestion
                {
                    Heading = "Reset my password",
                    Body = "I seem to be unable to log on to the webstore with my username and password. How do I reset my password?",
                    Answer = "The only way to reset your password is to bribe the admin. Hint: He wants a new graphics adapter for christmas",
                    RespondEmail = "ola@online.no",
                    RelevanceScore = 11,
                    CategoryID = 3
                },
                new DbQuestion
                {
                    Heading = "Shopping cart living it's own life",
                    Body = "When I am adding products to my shopping cart it does not show the right total price. What is this?",
                    Answer = "This is a hidden fee that you are not supposed to notice. We are sorry for this and will try to hide it better in the future",
                    RespondEmail = "ola@online.no",
                    RelevanceScore = 1,
                    CategoryID = 2
                }
            };

            foreach (var q in Questions)
                context.Questions.Add(q);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}