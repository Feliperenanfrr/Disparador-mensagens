namespace Gweb.WhatsApp.Util
{
    class Grupo
    {
        public class ApiResponse<T>
        {
            public int Code { get; set; }
            public string Status { get; set; }
            public T Data { get; set; }
        }

        public class DadosGrupo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime? DeletedAt { get; set; }
            public List<Contact> Contacts { get; set; }
        }

        public class Contact
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
            public Person Person { get; set; }
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


    }
}
