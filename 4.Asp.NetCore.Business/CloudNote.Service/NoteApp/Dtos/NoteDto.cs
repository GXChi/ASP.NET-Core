using CloudNote.Domain;

namespace CloudNote.Service.NoteApp.Dtos
{
    public class NoteDto : BaseEntity
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
