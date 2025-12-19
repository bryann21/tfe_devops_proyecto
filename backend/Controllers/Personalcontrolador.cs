using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiProyectoWeb.Data;
using MiProyectoWeb.Models;
using System.Threading.Tasks;

namespace MiProyectoWeb.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppController(AppDbContext context)
        {
            _context = context;
        }

        // ========================= ESTADOS =========================
        [HttpGet("estados")]
        public async Task<IActionResult> GetEstados() =>
            Ok(await _context.Estados.ToListAsync());

        [HttpGet("estados/{id}")]
        public async Task<IActionResult> GetEstado(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            return estado == null ? NotFound() : Ok(estado);
        }

        // ========================= CLIENTES =========================
        [HttpGet("clientes")]
        public async Task<IActionResult> GetClientes() =>
            Ok(await _context.Clientes.ToListAsync());

        [HttpGet("clientes/{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        // ========================= PERSONAL =========================
    [HttpGet("personal")]
        public async Task<IActionResult> GetPersonales() =>
            Ok(await _context.Personales.ToListAsync());

        [HttpGet("personal/{id}")]
        public async Task<IActionResult> GetPersonal(string id)
        {
            var persona = await _context.Personales
                .FirstOrDefaultAsync(p => p.IdPer == id);

            return persona == null ? NotFound() : Ok(persona);
        }

        // ========================= DEPARTAMENTOS =========================
        [HttpGet("departamentos")]
    public async Task<IActionResult> GetDepartamentos() =>
        Ok(await _context.Departamentos.ToListAsync());


    [HttpGet("departamentos/{id}")]
    public async Task<IActionResult> GetDepartamento(string id)
    {
        var depto = await _context.Departamentos
            .FirstOrDefaultAsync(d => d.IdDep == id);

        return depto == null ? NotFound() : Ok(depto);
    }

// ========================= TECNICOS =========================
    [HttpGet("tecnicos")]
        public async Task<IActionResult> GetTecnicos() =>
            Ok(await _context.Tecnicos.ToListAsync());

        [HttpGet("tecnicos/{id}")]
        public async Task<IActionResult> GetTecnico(int id)
        {
            var tecnico = await _context.Tecnicos
                .FirstOrDefaultAsync(t => t.IdTec == id);

            return tecnico == null ? NotFound() : Ok(tecnico);
}



        // ========================= CAMIONETAS =========================
        [HttpGet("camionetas")]
        public async Task<IActionResult> GetCamionetas() =>
            Ok(await _context.Camionetas.ToListAsync());

        [HttpGet("camionetas/{id}")]
        public async Task<IActionResult> GetCamioneta(int id)
        {
            var cam = await _context.Camionetas.FindAsync(id);
            return cam == null ? NotFound() : Ok(cam);
        }

        // ========================= OFICINAS =========================
        [HttpGet("oficinas")]
        public async Task<IActionResult> GetOficinas() =>
            Ok(await _context.Oficinas.ToListAsync());

        [HttpGet("oficinas/{id}")]
        public async Task<IActionResult> GetOficina(int id)
        {
            var ofi = await _context.Oficinas
                .FirstOrDefaultAsync(o => o.IdOfi == id);

            return ofi == null ? NotFound() : Ok(ofi);
        }

        // ========================= SMARTS =========================
        [HttpGet("smarts")]
        public async Task<IActionResult> GetSmarts() =>
            Ok(await _context.Smarts.ToListAsync());

        [HttpGet("smarts/{id}")]
        public async Task<IActionResult> GetSmart(int id)
        {
            var smart = await _context.Smarts.FindAsync(id);
            return smart == null ? NotFound() : Ok(smart);
        }

        // ========================= CONEXIONES =========================
        [HttpGet("conexiones")]
        public async Task<IActionResult> GetConexiones() =>
            Ok(await _context.Conexiones.Include(c => c.Smart).ToListAsync());

        [HttpGet("conexiones/{id}")]
        public async Task<IActionResult> GetConexion(int id)
        {
            var conexion = await _context.Conexiones
                .Include(c => c.Smart)
                .FirstOrDefaultAsync(c => c.IdCon == id);
            return conexion == null ? NotFound() : Ok(conexion);
        }

        // ========================= NOTAS =========================
        [HttpGet("notas")]
        public async Task<IActionResult> GetNotas() =>
            Ok(await _context.Notas.Include(n => n.Descripcion).ToListAsync());

        [HttpGet("notas/{id}")]
        public async Task<IActionResult> GetNota(int id)
        {
            var nota = await _context.Notas
                .Include(n => n.Descripcion)
                .FirstOrDefaultAsync(n => n.IdNota == id);
            return nota == null ? NotFound() : Ok(nota);
        }

        // ========================= DETALLE_NOTAS =========================
        [HttpGet("detalle-notas")]
        public async Task<IActionResult> GetDetalleNotas() =>
            Ok(await _context.DetalleNotas.ToListAsync());

        [HttpGet("detalle-notas/{id}")]
        public async Task<IActionResult> GetDetalleNota(int id)
        {
            var detalle = await _context.DetalleNotas.FindAsync(id);
            return detalle == null ? NotFound() : Ok(detalle);
        }

        // ========================= DANOS =========================
        [HttpGet("danos")]
        public async Task<IActionResult> GetDanos() =>
            Ok(await _context.Danos.ToListAsync());

        [HttpGet("danos/{id}")]
        public async Task<IActionResult> GetDano(int id)
        {
            var dano = await _context.Danos.FindAsync(id);
            return dano == null ? NotFound() : Ok(dano);
        }

        // ========================= DANOS_DIA =========================
        [HttpGet("danos-dia")]
        public async Task<IActionResult> GetDanosDia() =>
            Ok(await _context.DanosDia.ToListAsync());

        [HttpGet("danos-dia/{id}")]
        public async Task<IActionResult> GetDanoDia(int id)
        {
            var danoDia = await _context.DanosDia.FindAsync(id);
            return danoDia == null ? NotFound() : Ok(danoDia);
        }

        // ========================= REAGENDAR =========================
        [HttpGet("reagendar")]
        public async Task<IActionResult> GetReagendar() =>
            Ok(await _context.Reagendar.ToListAsync());

        [HttpGet("reagendar/{id}")]
        public async Task<IActionResult> GetReagendarId(int id)
        {
            var item = await _context.Reagendar.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        // ========================= DETALLE_REAGENDADOS =========================
        [HttpGet("detalle-reagendados")]
        public async Task<IActionResult> GetDetalleReagendados() =>
            Ok(await _context.DetalleReagendados.ToListAsync());

        [HttpGet("detalle-reagendados/{id}")]
        public async Task<IActionResult> GetDetalleReagendado(int id)
        {
            var item = await _context.DetalleReagendados.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        // ========================= PLANES =========================
        [HttpGet("planes")]
        public async Task<IActionResult> GetPlanes() =>
            Ok(await _context.Planes.ToListAsync());

        [HttpGet("planes/{id}")]
        public async Task<IActionResult> GetPlan(int id)
        {
            var plan = await _context.Planes.FindAsync(id);
            return plan == null ? NotFound() : Ok(plan);
        }
        // ========================== LOGIN ==============================
       [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Usuario) || string.IsNullOrEmpty(request.Contrasena))
            {
                return BadRequest(new { mensaje = "Por favor, ingrese usuario y contraseña." });
            }

            var persona = _context.Personales
                .FirstOrDefault(p => p.IdPer == request.Usuario && p.ConPer == request.Contrasena);

            if (persona == null)
            {
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos." });
            }

            return Ok(new
            {
                mensaje = "Inicio de sesión exitoso",
                nombre = persona.NomPer,
            });
        }


    }
}

