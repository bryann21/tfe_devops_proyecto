import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"; 
import axios from "axios";
import '../estilos/Departamentos.css'; // (opcional si luego quieres agregar estilos)

export function Departamentos() {
  const [departamentos, setDepartamentos] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchDepartamentos = async () => {
      try {
        const response = await axios.get("/api/App/departamentos");
        setDepartamentos(response.data);
      } catch (err) {
        console.error("Error al obtener los departamentos:", err);
        setError("No se pudo cargar la lista de departamentos.");
      }
    };

    fetchDepartamentos();
  }, []);

  return (
    <div style={{ padding: "2rem" }}>
      <h1>📋 Lista de Departamentos</h1>
    <button className="volver-btn" onClick={() => navigate("/admin")}>
              ⬅ Volver al Panel
            </button>
      {error && <p style={{ color: "red" }}>{error}</p>}

      <table border="1" cellPadding="8">
        <thead>
          <tr>
            <th>Alias</th>
            <th>Nombre del Departamento</th>
          </tr>
        </thead>
        <tbody>
          {departamentos.map((dep) => (
            <tr key={dep.idDep}>
              <td>{dep.idDep}</td>
              <td>{dep.nombreDepartamento}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
