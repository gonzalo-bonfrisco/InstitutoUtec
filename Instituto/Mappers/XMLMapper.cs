using Instituto.Constants;
using Instituto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Mappers
{
    public class XMLMapper
    {
        public string GetKey(XMLEnum key)
        {
            switch (key)
            {
                case XMLEnum.Alumnos: return XMLConstants.XmlAlumnos;
                case XMLEnum.Materias: return XMLConstants.XmlMaterias;
                default: return string.Empty;
            }

        }
    }
}
