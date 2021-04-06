using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTechCore.Models.Document
{
    public interface IDocumentBase
    {
        CTechCore.Enums.Document.Type DocumentType { get; }

        bool Save();
        void Reload(DataTable dr);
        bool Process();
        void Delete();
        void PrintDocument();
        void eMailDocument();
    }
}
