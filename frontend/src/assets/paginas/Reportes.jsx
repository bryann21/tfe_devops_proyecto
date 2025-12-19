import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "../estilos/Reportes.css";

export function Reportes() {
  const [reportes, setReportes] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchReportes = async () => {
      try {
        // 
        const response = await axios.get("/api/App/danos-dia");
        setReportes(response.data);
      } catch (err) {
        console.error("Error al obtener los reportes:", err);
        setError("No se pudo cargar la lista de reportes.");
      }
    };

    fetchReportes();
  }, []);

  return (
    <div className="contenedor">
      <h1>📊 Lista de Reportes</h1>

      <button className="volver-btn" onClick={() => navigate("/admin")}>
        ⬅ Volver al Panel
      </button>

      {error && <p className="error">{error}</p>}

      <table className="tabla-reportes">
        <thead>
          <tr>
            <th>ID</th>
            <th>Clasificación</th>
            <th>fecha de reporte</th>
            <th>identificativo del cliente que reporta</th>
            <th>Plan que dispone</th>
            <th>Estado del soporte</th>
          </tr>
        </thead>
        <tbody>
          {reportes.map((rep) => (
            <tr key={rep.idDanoDia}>
              <td>{rep.idDanoDia}</td>
              <td>{rep.tipoDan}</td>
              <td>{rep.fechaDan}</td>
              <td>{rep.cedCli}</td>
              <td>{rep.idPla}</td>
              <td>{rep.idEst}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
