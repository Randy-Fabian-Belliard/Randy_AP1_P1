using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Randy_AP1_P1;
using System.Linq.Expressions;

public class AportesBLL
{
    private Contexto _contexto;

    public AportesBLL(Contexto contexto)
    {
        _contexto = contexto;
    }


    public bool Existe(int id)
    {
        return _contexto.Aportes.Any(p => p.AportesId == id);
    }

    public bool Eliminar(Aportes aportes)
    {
        _contexto.Aportes.Remove(aportes);
        int eliminado = _contexto.SaveChanges();
        return eliminado > 0;
    }

    public bool Insertar(Aportes aportes)
    {
        _contexto.Aportes.Add(aportes);
        int guardado = _contexto.SaveChanges();
        return guardado > 0;
    }

    public bool Modificar(Aportes aportes)
    {
        _contexto.Update(aportes);
        int modificado = _contexto.SaveChanges();
        return modificado > 0;
    }

    public bool Guardar(Aportes aportes)
    {
        if (!Existe(aportes.AportesId))
        {
            return Insertar(aportes);
        }
        else
        {
            return Modificar(aportes);
        }
    }

    public Aportes? Buscar(int AportesId)
    {
        return _contexto.Aportes
            .Where(O => O.AportesId == AportesId)
            .AsNoTracking()
            .SingleOrDefault();
    }

    public List<Aportes> Listar(Expression<Func<Aportes, bool>> Criterio)
    {
        return _contexto.Aportes
            .Where(Criterio)
            .AsNoTracking().ToList();
    }

    
}