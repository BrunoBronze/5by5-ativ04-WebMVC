namespace Model
{
    public class Meal
    {
        public const string select = "SELECT Id, Description, Value FROM TB_MEAL";
        public const string selectById = "SELECT Id, Description, Value FROM TB_MEAL where id = {0}";
        public const string insert = "INSERT INTO TB_MEAL VALUES ({0})";
        public const string update = "UPDATE TB_MEAL SET Description = '{0}', Value = {1} WHERE id = {2}";
        public const string delete = "DELETE FROM TB_MEAL WHERE Id = {0}";
        public const string selectTotal = "SELECT Description, Value FROM TB_MEAL WHERE Id = {0}";

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Pizza Pizza { get; set; }

        public override string ToString()
        {
            return $"'{Description}',{Value:F2}";
        }
    }
}
