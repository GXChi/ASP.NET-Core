namespace CloudNote.Domain.Entities
{
    public class DatumEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Path { get; set; }
        public bool IsCollection { get; set; }
        public bool IsDelete { get; set; }
        public bool IsPublish { get; set; }
    }
}
