using System;

namespace WpfTemplateApp.Domain.Commons;

public class Auditable
{
    public int Id { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreateAt { get; set; }
}