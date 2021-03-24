namespace Model
{
    public class Pizza
    {
        public const string select = "SELECT Id FROM TB_PIZZA";
        public const string insert = "INSERT INTO TB_PIZZA VALUES ('{0}')";
        public const string remove = "DELETE FROM TB_PIZZA WHERE Id = {0};";

        public int Id { get; set; }
    }
}
