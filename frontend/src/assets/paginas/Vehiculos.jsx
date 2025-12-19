import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "../estilos/Vehiculos.css";

export function Vehiculos() {
  const [camionetas, setCamionetas] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchVehiculos = async () => {
      try {
        // 
        const response = await axios.get("/api/App/camionetas");
        setCamionetas(response.data);
      } catch (err) {
        console.error("Error al obtener las camionetas:", err);
        setError("No se pudo cargar la lista de camionetas.");
      }
    };

    fetchVehiculos();
  }, []);

  return (
    <div className="contenedor">
      <h1>🚐 Lista de Camionetas</h1>

      <button className="volver-btn" onClick={() => navigate("/admin")}>
        ⬅ Volver al Panel
      </button>

      {error && <p className="error">{error}</p>}

      <table className="tabla-camionetas">
        <thead>
          <tr>
            <th>ID</th>
            <th>Alias</th>
            
          </tr>
        </thead>
        <tbody>
          {camionetas.map((cam) => (
            <tr key={cam.idCam}>
              <td>{cam.idCam}</td>
              <td>{cam.nomCam}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
export default Vehiculos;