namespace Architecture.Core.Entities.LU
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
