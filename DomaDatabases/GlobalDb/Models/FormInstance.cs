﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GlobalDb.Models;

public partial class FormInstance
{
    public string FormInstanceId { get; set; }

    public string FormId { get; set; }

    public int? HasUploadedSuccesfully { get; set; }

    public string FormInstanceName { get; set; }

    public long? DateCreated { get; set; }

    public int? HasBeenSaved { get; set; }

    public int? HasExported { get; set; }

    public int? HasExportError { get; set; }
}