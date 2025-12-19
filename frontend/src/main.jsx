import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Login } from "./assets/paginas/Login.jsx";
import { Admin } from "./assets/paginas/Admin.jsx";
import { Personal_oficina } from "./assets/paginas/Personal_oficina.jsx";
import { Departamentos } from "./assets/paginas/Departamentos.jsx";
import { Vehiculos } from "./assets/paginas/Vehiculos.jsx";
import { Clientes } from "./assets/paginas/Clientes.jsx";
import { Reportes } from "./assets/paginas/Reportes.jsx";
import { Tecnicos } from "./assets/paginas/Tecnicos.jsx";
import { Planes } from "./assets/paginas/Planes.jsx";
import { Sistema } from "./assets/paginas/Sistema.jsx";



import "./index.css";

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/admin" element={<Admin />} />
        <Route path="/personal" element={<Personal_oficina />} /> 
        <Route path="/departamentos" element={<Departamentos />} />
        <Route path="/vehiculos" element={<Vehiculos />} />
        <Route path="/clientes" element={<Clientes />} />
        <Route path="/reportes" element={<Reportes />} />
        <Route path="/tecnicos" element={<Tecnicos />} />
        <Route path="/planes" element={<Planes />} />
        <Route path="/sistema" element={<Sistema />} />
      </Routes>
    </BrowserRouter>
  </StrictMode>
);
