using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InformationToolOIM2.Utils
{
    public class Finders
    {
        private OimContext db = new OimContext();

        // Finding the corresponding id to the description that came in the excel.
        public int IdFinderCriterioMovilidad(String nombre)
        {
            List<CriterioMovi> CriterioM = db.CriterioMovis.ToList();
            int id = 999999;
            foreach (CriterioMovi cm in CriterioM)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (cm.Descripcion.Contains(nombre.ToUpper()))
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


            return id;
        }
        public int IdFinderGenero(String nombre)
        {
            List<Sexo> genero = db.Sexos.ToList();
            int id = 999999;            
            foreach (Sexo Gen in genero)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Gen.Descripcion.Contains(nombre.ToUpper())) {
                    id = Gen.IdSexo;
                    break;
                } else if (Gen.Descripcion.Contains("OTRO"))
                //If the giving gender is not in the table, return the id for 'OTRO' value
                {
                    id = Gen.IdSexo;
                }
            }
           
           
            return id;
        }
        public int IdFinderNacionalidad(String nombre)
        {
            List<Nacionalidad> nacionalidad = db.Nacionalidads.ToList();
            int id = 999999;
            foreach (Nacionalidad Nac in nacionalidad)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Nac.Descripcion.Contains(nombre.ToUpper()))
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


            return id;
        }
        public int IdFinderParentezco(String nombre)
        {
            List<Parentezco> parentezco = db.Parentezcos.ToList();
            int id = 999999;
            foreach (Parentezco Par in parentezco)
            {
                //If the giving gender is in the table, return its id and break the loop
                if (Par.Descripcion.Contains(nombre.ToUpper()))
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