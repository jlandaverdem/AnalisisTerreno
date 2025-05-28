using UnidadesAgua.Models;

namespace UnidadesAgua.DataAccess
{
    public class DATerreno
    {
        public void AlmacenaTerreno(AlturaTerreno terreno)
        { 
            AnalisisTerrenoContext context = new AnalisisTerrenoContext();
            context.AlturaTerrenos.Add(terreno);
            context.SaveChanges();
        }

        public AlturaTerreno ConsultaTerreno(int posicion)
        {
            AnalisisTerrenoContext context = new AnalisisTerrenoContext();
            var terreno = context.AlturaTerrenos.FirstOrDefault(x => x.Posicion ==posicion);

            return terreno;
        }
    }
}
