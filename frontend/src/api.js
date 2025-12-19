import axios from "axios";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL, // 👈 usa tu puerto real del backend
  headers: {
    "Content-Type": "application/json",
  },
});

// Función para obtener el personal
export const getPersonal = async () => {
  const response = await api.get("/App/personal"); // 👈 endpoint de tu controlador
  return response.data;
};
export default api; // 👈 Agrega esta línea