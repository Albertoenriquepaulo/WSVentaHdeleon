using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentaHdeleon.Models;
using WSVentaHdeleon.Models.Response;
using WSVentaHdeleon.Models.ViewModels;
using WSVentaHdeleon.Repository.IRepository;

namespace WSVentaHdeleon.Repository
{
    public class ClientRepository : IClientRepository
    {
        public Respuesta GetAll()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    respuesta.Data = db.Cliente.ToList();
                    respuesta.Ok();
                }
            }
            catch (Exception ex)
            {
                respuesta.Bad(ex.Message);
            }
            return respuesta;
        }
        public Respuesta GetOne(int id)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = db.Cliente.Find(id);
                    if (cliente == null)
                    {
                        respuesta.Bad("Id no asociado a ningun cliente");
                    }
                    else
                    {
                        respuesta.Ok(cliente, $"Client with id = {id} was found");
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Bad(ex.Message);
            }

            return respuesta;
        }

        public Respuesta Create(ClienteVM oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = new Cliente
                    {
                        Nombre = oModel.Nombre
                    };
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    respuesta.Ok(cliente);
                }
            }
            catch (Exception ex)
            {
                respuesta.Bad(ex.Message);
            }
            return respuesta;
        }

        public Respuesta Update(ClienteVM oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = db.Cliente.Find(oModel.Id);
                    if (cliente == null)
                    {
                        respuesta.Bad("Id no asociado a ningun cliente");
                    }
                    else
                    {
                        cliente.Nombre = oModel.Nombre;
                        //db.Entry(cliente).State = EntityState.Modified OJO -> Esta linea tiene el mismo efecto que la de abajo
                        db.Cliente.Update(cliente);
                        db.SaveChanges();
                        respuesta.Ok(cliente, "Changes Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Bad(ex.Message);
            }
            return respuesta;
        }
        public Respuesta Delete(int id)
        {
            Respuesta respuesta = new Respuesta();

            if (id == 0)
            {
                respuesta.Bad("Debe especificar un Id");
                return respuesta;
            }

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = db.Cliente.Find(id);
                    if (cliente == null)
                    {
                        respuesta.Bad("Id no asociado a ningun cliente");
                    }
                    else
                    {
                        db.Cliente.Remove(cliente);
                        db.SaveChanges();
                        respuesta.Ok(cliente, $"Client with id = {id} was deleted");
                    }

                }
            }
            catch (Exception ex)
            {
                respuesta.Bad(ex.Message);
            }
            return respuesta;
        }
    }
}
