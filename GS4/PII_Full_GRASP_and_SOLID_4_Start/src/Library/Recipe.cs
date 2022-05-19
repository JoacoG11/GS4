//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID
{
    public class Recipe
    {
        private IList<Step> steps = new List<Step>();

        public Product FinalProduct { get; set; }

        //Modificamos la clase Recipe 
        //para asignarle la responsabilidad de crear instancias de Step
        //El método AddStep de la clase Recipe recibe como argumento todos los datos 
        //necesarios para crear instancias de Step. Notese que además de crear la instancia, 
        //el objeto recién creado se agrega a steps, con lo cual es menos probable que existan 
        //instancias de Step que no pertenezcan a alguna instancia de Recipe.
        public void AddStep(Product prod, double cost, Equipment equi, int time)
        {
            Step step1 = new Step(prod, cost, equi, time);
            this.steps.Add(step1);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        // Agregado por SRP
        public string GetTextToPrint()
        {
            string result = $"Receta de {this.FinalProduct.Description}:\n";
            foreach (Step step in this.steps)
            {
                result = result + step.GetTextToPrint() + "\n";
            }

            // Agregado por Expert
            result = result + $"Costo de producción: {this.GetProductionCost()}";

            return result;
        }

        // Agregado por Expert
        public double GetProductionCost()
        {
            double result = 0;

            foreach (Step step in this.steps)
            {
                result = result + step.GetStepCost();
            }

            return result;
        }
    }
}