import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import "../estilos/Personal_oficina.css";

export function Personal_oficina() {
  const [personal, setPersonal] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchPersonal = async () => {
      try {
        // 
        const response = await fetch("/api/App/personal");

        if (!response.ok) {
          throw new Error(`Error HTTP: ${response.status}`);
        }

        const data = await response.json();
        setPersonal(data);
      } catch (err) {
        console.error("Error al obtener el personal:", err);
      }
    };

    fetchPersonal();
  }, []);

  return (
    <div className="personal-container">
      <header className="personal-header">
        <h1>Gestión de Personal</h1>
        <button className="volver-btn" onClick={() => navigate("/admin")}>
          ⬅ Volver al Panel
        </button>
      </header>

      <table className="personal-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Contraseña</th>
            
          </tr>
        </thead>
        <tbody>
          {personal.length > 0 ? (
            personal.map((p) => (
              
              <tr key={p.idPer}>
                <td>{p.idPer }</td>
                <td>{p.nomPer }</td>
                <td>{p.conPer }</td>
                </tr>
            ))
          ) : (
            <tr>
              <td colSpan="4">No hay registros disponibles</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}

export default Personal_oficina;
