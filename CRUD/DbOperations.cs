using ConsoleTableExt;
using Flashcards.Model;
using System.Data.SqlClient;


namespace Flashcards.CRUD {
    internal static class DbOperations {

        private static SqlDataReader reader;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        static string dbConnection = @"Data Source=DESKTOP-SFORHI9;Initial Catalog=test;User ID=vocal;Password=spider12";
        static SqlConnection cnn = new SqlConnection( dbConnection);

        public static void AddStack( string op ) {
            Console.Clear();
            cnn.Open();
            

            string sql = $"Insert into Stack (name) values('{op}')";
            var command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        public static List<Stack> ShowStacksList() {

            List<Stack> stacks = new List<Stack>();

            cnn.Open();

            string sql = "SELECT * from Stack";

            var command = new SqlCommand(sql, cnn);
            reader = command.ExecuteReader();

            while (reader.Read()) {
  
                string id = reader.GetValue(0).ToString();
                string name = reader.GetValue(1).ToString();

                var stack = new Stack(id, name);
                stacks.Add(stack);
            }

            cnn.Close();
            return stacks;
        }

        public static void DeleteStack( Stack stack ) {
            cnn.Open();

            string sql = $"DELETE Cards where stack_id = {stack.Id}";

            var command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();

            sql = $"DELETE Stack where stack_id = {stack.Id}";

            command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        public static void CreateCard( string front, string back, Stack stack ) {
            cnn.Open();

            string sql = $"Insert into Cards (front, back, stack_id) values('{front}', '{back}', {stack.Id})";
            var command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        public static List<CardDto> GetFlashcards(Stack stack) {

            cnn.Open();

            List<CardDto> cards = new List<CardDto>();

            string sql = $"SELECT * from Cards WHERE stack_id = {stack.Id}";

            var command = new SqlCommand(sql, cnn);
            reader = command.ExecuteReader();

            while (reader.Read()) {
                var id = reader.GetValue(0).ToString();
                var front = reader.GetValue(1).ToString();
                var back = reader.GetValue(2).ToString();

                CardDto card = new CardDto(id, front, back);
                cards.Add(card);
            }
            cnn.Close();
            return cards;       
        }

        internal static List<CardDto> GetFlashcardsWithId(Stack stack) {

            Console.Clear();

            List<CardDto> cards = new List<CardDto>();
            int id = 1;

            cnn.Open();

            string sql = $"SELECT * from Cards WHERE stack_id = {stack.Id}";

            var command = new SqlCommand(sql, cnn);
            reader = command.ExecuteReader();

            while (reader.Read()) {

                var front = reader.GetValue(1).ToString();
                var back = reader.GetValue(2).ToString();

                CardDto card = new CardDto(id.ToString(), front, back);
                cards.Add(card);
                id++;
            }

            cnn.Close();
            return cards;
        }

        internal static void GetCard(CardDto card) {

            cnn.Open();
            List<List<object>> table;

            string sql = $"SELECT * from Cards WHERE card_id = {card.Id}";

            var command = new SqlCommand(sql, cnn);
            reader = command.ExecuteReader();

            while (reader.Read()) {
                var front = reader.GetValue(1).ToString();
                var back = reader.GetValue(2).ToString();

                table = new List<List<object>> {
                    new List<object> { front, back }
                };

                ConsoleTableBuilder
               .From(table)
               .WithColumn("Front", "Back")
               .ExportAndWriteLine();
            }
            cnn.Close();
        }

        internal static void UpdateCardText(bool front, string nextText, CardDto card) {

            cnn.Open();
            string sql;

            if (front == true) {
                sql = $"UPDATE Cards SET front = '{nextText}'  WHERE card_id = {card.Id}";
            } else {
                sql = $"UPDATE Cards SET back = '{nextText}'  WHERE card_id = {card.Id}";
            }

            var command = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();

            command.Dispose();

            cnn.Close();
        }

        internal static void DeleteCard(string id) {

            cnn.Open();

            string sql = $"DELETE Cards where card_id = {id}";

            var command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }
    }
}
