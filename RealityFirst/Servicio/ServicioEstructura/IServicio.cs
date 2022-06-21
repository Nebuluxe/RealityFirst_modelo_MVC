using System.Collections.Generic;
using RealityFirst.Models;

namespace RealityFirst.Servicio.ServicioEstructura
{
    public interface IServicio<T>
    {
        public IList<T> GetAll();
        public T Get(int id);
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(int id);


        /*
            C.R.U.D.
        C-CREATE --> INSERT
        R-READ   --> SELECT --> TODOS Y UNO
        U-UPDATE --> UPDATE
        D-DELETE --> DELETE
            */
    }

}
