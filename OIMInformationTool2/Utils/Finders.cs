using OIMInformationTool2.Models;
using OIMInformationTool2.Utils;

namespace InformationToolOIM2.Utils
{
    public class Finders
    {
        TextCleaning helper = new TextCleaning();

        // Finding the corresponding id to the description that came in the excel.
        public int IdFinderCriterioMovilidad(String nombre, List<CriterioMovi> CriterioM)
        {
            nombre = helper.ReplaceAccents(nombre);
            int id = 999999;
            foreach (CriterioMovi cm in CriterioM)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (cm.Descripcion.Contains(nombre))
                {
                    id = cm.IdCriterioMovi;
                    break;
                }
                else if (cm.Descripcion.Contains("S/I"))
                //If the giving gender is not in the table, return the id for 'OTRO' value
                {
                    id = cm.IdCriterioMovi;
                }
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + " ENCONTRÉ EL ID********************");
            return id;
        }
        public int IdFinderGenero(String nombre, List<Genero> genero)
        {
            nombre = helper.ReplaceAccents(nombre);

            int id = 999999;
            foreach (Genero Gen in genero)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Gen.Descripcion.Contains(nombre)) {
                    id = Gen.IdGenero;
                    break;
                } else if (Gen.Descripcion.Contains("OTRO"))
                //If the giving gender is not in the table, return the id for 'OTRO' value
                {
                    id = Gen.IdGenero;
                }
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + " ENCONTRÉ EL ID********************");
            return id;
        }

        public int IdFinderIdentidadSexual(String nombre, List<IdentSexual> lista)
        {
            nombre = helper.ReplaceAccents(nombre);

            int id = 999999;
            foreach (IdentSexual Gen in lista)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Gen.Descripcion.Contains(nombre))
                {
                    id = Gen.IdIdentSexual;
                    break;
                }
                else if (Gen.Descripcion.Contains("OTRO"))
                //If the giving gender is not in the table, return the id for 'OTRO' value
                {
                    id = Gen.IdIdentSexual;
                }
            }
           
            return id;
        }

        public int IdFinderSexo(String nombre, List<Sexo> lista)
        {
            nombre = helper.ReplaceAccents(nombre);

            int id = 999999;
            foreach (Sexo Gen in lista)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Gen.Descripcion.Contains(nombre))
                {
                    id = Gen.IdSexo;
                    break;
                }
                else if (Gen.Descripcion.Contains("OTRO"))
                //If the giving gender is not in the table, return the id for 'OTRO' value
                {
                    id = Gen.IdSexo;
                }
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + " ENCONTRÉ EL ID********************");
            return id;
        }
        public int IdFinderNacionalidad(String nombre, List<Nacionalidad> nacionalidad)
        {
            nombre = helper.ReplaceAccents(nombre);
            int id = 999999;
            foreach (Nacionalidad Nac in nacionalidad)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Nac.Descripcion.Contains(nombre))
                {
                    id = Nac.IdNacionalidad;
                    break;
                }
                else if (Nac.Descripcion.Contains("S/I"))
                //If the giving gender is not in the table, return the id for 'OTRO' value
                {
                    id = Nac.IdNacionalidad;
                }
            }

            System.Diagnostics.Debug.WriteLine(id.ToString() + " ENCONTRÉ EL ID ********************");
            return id;
        }
        public int IdFinderParentezco(String nombre, List<Parentezco> parentezco)
        {
            int id = 999999;
            nombre = helper.ReplaceAccents(nombre);
            foreach (Parentezco Par in parentezco)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Par.Descripcion.Contains(nombre))
                {
                    id = Par.IdParentezco;
                    break;
                }
                else if ((Par.Descripcion.Contains("S/I")) | (Par.Descripcion.Contains("N/A")))
                //If the giving gender is not in the table, return the id for 'OTRO' value
                {
                    id = Par.IdParentezco;
                }
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + " ENCONTRÉ EL ID********************");
            return id;
        }
        public bool DiscapacidadTranformer(String discapacidad)
        {
            bool value = false;
            if ((discapacidad.ToUpper().Contains("NO")) | (discapacidad.ToUpper().Contains("0")))
            {
                value = false;
            }
            else
            {
                value = true;
            }
            return value;
        }



    }
}