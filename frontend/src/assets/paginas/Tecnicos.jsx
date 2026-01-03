import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "../estilos/Tecnicos.css";

export function Tecnicos() {
  const [tecnicos, setTecnicos] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchTecnicos = async () => {
      try {
        // 
        const response = await axios.get("/api/App/tecnicos");
         const data = response.data;
        setTecnicos(data);
      } catch (err) {
        console.error("Error al obtener los técnicos:", err);
        setError("No se pudo cargar la lista de técnicos.");
      }
    };

    fetchTecnicos();
  }, []);

  return (
    <div className="contenedor">
      <h1>👨‍🔧 Reporte del personal técnico</h1>

      <button onClick={() => navigate("/admin")}>

        ⬅ Volver al Panel
      </button>

      {error && <p className="error">{error}</p>}

      <table className="Reporte del personal técnico">
        <thead>
          <tr>
            <th>ID</th>
            <th>Causa</th>
            <th>Solución</th>
            <th>Vehiculo</th>
            <th>Fecha de ingreso del daño</th>
            <th>Fecha de solución del daño</th>
          </tr>
        </thead>
        <tbody>
          {tecnicos.map((tec) => (
            <tr key={tec.idTec}>
              <td>{tec.idTec}</td>
              <td>{tec.causa}</td>
              <td>{tec.solucion}</td>
              <td>{tec.idCam}</td>
              <td>{tec.fechaIngreso}</td>
              <td>{tec.fechaSolucion}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
