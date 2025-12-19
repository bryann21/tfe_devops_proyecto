import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import "../estilos/Clientes.css";

export function Clientes() {
  const [clientes, setClientes] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchClientes = async () => {
      try {
        //
        const response = await axios.get("/api/App/clientes");
        setClientes(response.data);
      } catch (err) {
        console.error("Error al obtener los clientes:", err);
        setError("No se pudo cargar la lista de clientes.");
      }
    };

    fetchClientes();
  }, []);

  return (
    <div className="contenedor">
      <h1>🧾 Lista de Clientes</h1>

      <button className="volver-btn" onClick={() => navigate("/admin")}>
        ⬅ Volver al Panel
      </button>

      {error && <p className="error">{error}</p>}

      <table className="tabla-clientes">
        <thead>
          <tr>
            <th>Cédula</th>
            <th>Nombre</th>
            <th>Domicilio</th>
            <th>Teléfono</th>
          </tr>
        </thead>
        <tbody>
          {clientes.map((cli) => (
            <tr key={cli.cedCliCli}>
              <td>{cli.cedCli}</td>
              <td>{cli.nomCli}</td>
              <td>{cli.dirCli}</td>
              <td>{cli.conCli}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
