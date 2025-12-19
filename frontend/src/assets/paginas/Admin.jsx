import React from "react";
import { useNavigate } from "react-router-dom";
import '../estilos/Admin.css';

export function Admin() {
  const navigate = useNavigate();

  return (
    <div className="admin-container">
      <header className="admin-header">
        <img src="/IMAGENES/imagen_admimistrador.png" alt="Logo" className="admin-logo" />
        <h1>Menú de navegación</h1>
      </header>

      <div className="admin-buttons">
        <button onClick={() => navigate("/personal")}>Gestión de Personal</button>
        <button onClick={() => navigate("/departamentos")}>Departamentos Administrativos</button>
        <button onClick={() => navigate("/vehiculos")}>Gestión de vehiculos</button>
        <button onClick={() => navigate("/clientes")}>Gestión de Clientes</button>
        <button onClick={() => navigate("/reportes")}>Reportes</button>
        <button onClick={() => navigate("/tecnicos")}>Informe técnico</button>
        <button onClick={() => navigate("/planes")}>Planes disponibles</button>
        <button onClick={() => navigate("/sistema")}>Verificación del sistema</button>
        
        

      </div>
    </div>
  );
}

export default Admin;
