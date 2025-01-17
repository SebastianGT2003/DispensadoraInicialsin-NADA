﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensador
{
    public class Dispensadora
    {
        Validaciones validar;
        public List<Producto> Productos { get; set; }
        public string Pago { get; set; }
        public Dispensadora()
        {
            validar = new Validaciones();
            this.Productos = new List<Producto>();  

            Producto Cocacola = new Producto();
            Cocacola.Codigo = "01";
            Cocacola.Nombre = "Coca Cola";
            Cocacola.Valor = 300;
            Cocacola.Categoria = "B";
            Cocacola.Cantidad = 3;

            Producto Solterita = new Producto();
            Solterita.Codigo = "02";
            Solterita.Nombre = "Solterita";
            Solterita.Valor = 200;
            Solterita.Categoria = "C";
            Solterita.Cantidad = 5;



            Producto Papas = new Producto();
            Papas.Codigo = "03";
            Papas.Valor = 1000;
            Papas.Nombre = "Papas Margaritas";
            Papas.Categoria = "C";
            Papas.Cantidad = 10;

            Producto Yogurt= new Producto();
            Yogurt.Codigo = "04";
            Yogurt.Valor = 100;
            Yogurt.Categoria = "C";
            Yogurt.Cantidad = 11;
            Yogurt.Nombre = "Yogurt";

            this.Productos.Add(Cocacola);
            this.Productos.Add(Solterita);
            this.Productos.Add(Papas);
            Productos.Add(Yogurt);


        }
        
        public bool AgregarProducto(Producto producto)
        {
            int enc= validar.ValidaProducto(producto.Codigo);
            if (enc>=0)
            {
                this.Productos[enc].SumarCantidad(producto.Cantidad);
                return true;
            }
            else
            {
                this.Productos.Add(producto);
                return false;
            }
            
        }
        public bool EleminarProducto(string codigo)
        {
            int enc = validar.ValidaProducto(codigo);
            if (enc >= 0) 
            {
                this.Productos.RemoveAt(enc);
                return true;
            }
            else
            {
                Console.WriteLine("El codigo no existe");
                return false;
            }
            
  
           
        }
        public bool ModificarProducto(Producto producto)
        {

            int enc = validar.ValidaProducto(producto.Codigo);
            if (enc >= 0)
            {
                this.Productos[enc].Nombre = producto.Nombre;
                this.Productos[enc].Cantidad = producto.Cantidad;
                this.Productos[enc].Categoria = producto.Categoria;
                this.Productos[enc].Valor = producto.Valor;
                return true;

            }
            else
            {
                Console.WriteLine("El codigo no existe");
                return false;
            }
            
        }
        /// Metodo para validar si las monedas tiene alguna letra.

        //Las monedas van a ser: 1000-500-200-100
        public Producto Vender(string codigo)
        {
            int enc = validar.ValidaProducto(codigo);
            if (enc >= 0)
            {
                if (this.Productos[enc].ValidarCantidad())
                {
                    string[] monedas = this.Pago.Split("-");
                    double total= validar.ValidarMonedas(monedas);

                    if (this.Productos[enc].ValidarValor(total))
                    {
                        this.Productos[enc].RestarProducto();
                        return this.Productos[enc];
                    }
                    

                }
                

            }

            return null;
        }



    }
}
