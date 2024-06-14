namespace TheWaterProject.Models
{
    public class Cart
    {
        //The Cart class is used to represent a shopping cart in the application. It contains a list of CartLine objects, which represent the items in the cart.
        public List<CartLine> Lines { get; set; } = new List<CartLine>();


        public virtual void AddItem(Project proj, int quantity)
        {
            CartLine? line = Lines
                .Where(x => x.Project.ProjectId == proj.ProjectId)
                .FirstOrDefault(); //FirstOrDefault() returns the first element of a sequence that satisfies a specified condition or a default value if no such element is found.
        
            //If the item is not already in the cart, add it
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = quantity
                });
            }
            //Otherwise, increase the quantity of the item in the cart
            else
            {
                line.Quantity += quantity;
            }
        }

        //Remove an item from the cart
        public virtual void RemoveLine(Project proj) =>
            Lines.RemoveAll(x => x.Project.ProjectId == proj.ProjectId);//RemoveAll() removes all the elements that match the conditions defined by the specified predicate


        public virtual void Clear() => Lines.Clear(); //Clear the cart

        //Calculate the total cost of the items in the cart
        public decimal ComputeTotal() =>
            //Lines.Sum(x => x.Project.Price * x.Quantity); //Sum() computes the sum of a sequence of numeric values
            Lines.Sum(x => 25 * x.Quantity); //Sum() computes the sum of a sequence of numeric values (25 is a placeholder for the price of the project


        //The below code is a nested class within the Cart class
        //Though it is not a common practice to have nested classes in C#, it is used here to represent the CartLine entity
        //Normally it would be somewhere else
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }
    }
}
