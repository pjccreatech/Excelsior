using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excelsior.Core.Models.Document
{
    public  interface IDocumentBase
    {
        Enums.Document.Type DocumentType { get; }

        bool Save();
        void Reload(DataRow dr);
        bool Process();
        void Delete();
        void PrintDocument();
        void eMailDocument();
    }
}
