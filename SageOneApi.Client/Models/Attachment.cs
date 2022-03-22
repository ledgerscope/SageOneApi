using System;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
    public class Attachment : SageOneAccountingEntity
    {
        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
        [JsonPropertyName("file")]
        public string File { get; set; }
        [JsonPropertyName("mime_type")]
        public string MimeType { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("file_extension")]
        public string FileExtension { get; set; }
        [JsonPropertyName("transaction")]
        public PropertyValueWithPath Transaction { get; set; }
        [JsonPropertyName("file_size")]
        public int FileSize { get; set; }
        [JsonPropertyName("file_name")]
        public string FileName { get; set; }
        [JsonPropertyName("$file_path")]
        public string FilePath { get; set; }
        [JsonPropertyName("attachment_context_type")]
        public PropertyValueWithPath AttachmentContextType { get; set; }
        [JsonPropertyName("attachment_context")]
        public PropertyValueWithPath AttachmentContext { get; set; }
        [JsonPropertyName("is_public")]
        public bool IsPublic { get; set; }
    }
}
