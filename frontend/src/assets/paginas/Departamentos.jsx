import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"; 
import axios from "axios";
import '../estilos/Departamentos.css';

export function Departamentos() {
  const [departamentos, setDepartamentos] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchDepartamentos = async () => {
      try {
        const response = await axios.get('/App/departamentos');

        // 🔑 AQUÍ ESTÁ EL FIX
        const data = response.data?.data ?? [];

        setDepartamentos(Array.isArray(data) ? data : []);
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
            <th>ID</th>
            <th>Nombre del Departamento</th>
          </tr>
        </thead>
        <tbody>
          {departamentos.length > 0 ? (
            departamentos.map((dep) => (
              <tr key={dep.idDep}>
                <td>{dep.idDep}</td>
                <td>{dep.nombreDepartamento}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="2">No hay departamentos</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}