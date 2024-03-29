﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Cinepolis.Models
{
    public class bdLogin
    {
        readonly SQLiteAsyncConnection db;
        public bdLogin()
        {
        }

        public bdLogin(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // -- Creación de tablas de base de datos
            db.CreateTableAsync<constructorLogin>();

        }



        public Task<List<constructorLogin>> listaempleados()
        {

            return db.Table<constructorLogin>().ToListAsync();
        }

        // buscar un empleado especifico por el codigo
        /*
        public Task<constructorLogin> ObtenerEmpleado(Int32 pcodigo)
        {
            return db.Table<constructorLogin>().Where(i => i.codigo == pcodigo).FirstOrDefaultAsync();
        }
        */
        public Task<constructorLogin> ObtenerCliente()
        {
            return db.Table<constructorLogin>().Where(i => i.correo != "").FirstOrDefaultAsync();
        }

        public Task<constructorLogin>ObtenerClientes(string correos)
        {
            // return db.Table<constructorLogin>().Where(i => i.correo == correos).FirstOrDefaultAsync();
            return db.Table<constructorLogin>().Where(i => i.correo == correos + " Order by codigo desc").FirstOrDefaultAsync();
        }

        // Guardar o actualizar empleado

        public Task<Int32> EmpleadoGuardar(constructorLogin emple)
        {
            if (emple.codigo != 0)
            {
                return db.UpdateAsync(emple);
                
            }
            else
            {
               // return db.InsertAsync(emple);
            return    db.InsertOrReplaceAsync(emple);
            }
        }

        public Task<Int32> EmpleadoBorrar(constructorLogin emple)
        {
            return db.DeleteAsync(emple);
        }



    }
}
