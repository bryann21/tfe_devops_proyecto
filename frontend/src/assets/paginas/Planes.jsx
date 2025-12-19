import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "../estilos/Planes.css";

export function Planes() {
  const [planes, setPlanes] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchPlanes = async () => {
      try {
        
        const response = await axios.get("/api/App/planes");
        setPlanes(response.data);
      } catch (err) {
        console.error("Error al obtener los planes:", err);
        setError("No se pudo cargar la lista de planes.");
      }
    };

    fetchPlanes();
  }, []);

  return (
    <div style={{ padding: "2rem" }}>
      <h1>📦 Lista de Planes</h1>

      <button className="volver-btn" onClick={() => navigate("/admin")}>
        ⬅ Volver al Panel
      </button>

      {error && <p style={{ color: "red" }}>{error}</p>}

      <table border="1" cellPadding="8">
        <thead>
          <tr>
            <th>ID</th>
            <th> Plan</th>
            <th>Precio</th>
          </tr>
        </thead>
        <tbody>
          {planes.map((plan) => (
            <tr key={plan.id}>
              <td>{plan.idPla}</td>
              <td>{plan.nomPla}</td>
              <td>{plan.valPla}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
