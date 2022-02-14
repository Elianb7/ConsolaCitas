using DBcontex;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class PrequiAp
    {
        readonly AgendaContex db;

        public PrequiAp(AgendaContex db)
        {
            this.db = db;
        }

        public List<Medico> Prerequisitos(Medico medico)
        {
            var prerequisitos = new List<Medico>();
        

            // Consultar la maedico
            var tmpMedico = db.medicos
                .Include(ma => ma.MallaMedicacs)
                .Single(me => me.Id == medico.Id);

            // Si no tiene malla, entonces no tiene prerequisitos
            if (tmpMedico.MallaMedicacs == null) return null;

            // Consultar los prerequisitos
            var tmpPreReq = db.prerequisitos
                .Include(pre => pre.Medico)
                .Where(pre => pre.MallaMedicaId == tmpMedico.MallaMedicacs.id);

            // Si no tiene prerequisitos, retorna null
            if (tmpPreReq == null) return null;

            // Preparo la lista de materias
            foreach (var pr in tmpPreReq)
            {
                var sublistaMedica = Prerequisitos(pr.Medico);
                if (sublistaMedica == null)
                {
                    prerequisitos.Add(pr.Medico);
                }
                else
                {
                    foreach (var submed in sublistaMedica)
                    {
                        prerequisitos.Add(submed);

                    }

                }

            }

            return prerequisitos;
        }
    }
}
