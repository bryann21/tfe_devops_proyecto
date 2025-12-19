import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "../estilos/Sistema.css";

export function Sistema() {
  const [sistemas, setSistemas] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchSistemas = async () => {
      try {
        
        const response = await axios.get("/api/App/smarts");
        setSistemas(response.data);
      } catch (err) {
        console.error("Error al obtener los sistemas:", err);
        setError("No se pudo cargar la lista de sistemas.");
      }
    };

    fetchSistemas();
  }, []);

  return (
    <div style={{ padding: "2rem" }}>
      <h1>⚙️ Servidores OLT disponibles</h1>

      <button className="volver-btn" onClick={() => navigate("/admin")}>
        ⬅ Volver al Panel
      </button>

      {error && <p style={{ color: "red" }}>{error}</p>}

      <table border="1" cellPadding="8">
        <thead>
          <tr>
            <th>OLT</th>
          </tr>
        </thead>
        <tbody>
          {sistemas.map((sis) => (
            <tr key={sis.idSmart|| sis.ID_Sistema || Math.random()}>

              <td>{sis.nombreSmart}</td>
              
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
