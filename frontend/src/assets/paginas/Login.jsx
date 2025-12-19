import { useState } from 'react';
import api from '../../api';
import '../estilos/Login.css';
import { useNavigate } from 'react-router-dom';

export function Login() {
  const [usuario, setUsuario] = useState('');
  const [contrasena, setContrasena] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const res = await api.post('/api/App/login',{
        Usuario: usuario,
        Contrasena: contrasena,
      });

      console.log('Login exitoso', res.data);
      setError('');

      // 👉 Si el backend devuelve token, guárdalo (opcional)
      if (res.data.token) {
        localStorage.setItem("token", res.data.token);
      }

      // 👉 REDIRECCIÓN A ADMIN
      navigate('/admin');

    } catch (err) {
      console.error(err);
      setError('Usuario o contraseña incorrecta');
    }
  };

  return (
    <div className="login-container">
      <h1 className="login-title">
        SISTEMA PARA EL REGISTRO DE DAÑOS Y REVISIONES DIARIAS
      </h1>

      <div className="login-images">
        <img
          src="/IMAGENES/LOGO PROGRAMA_MI MARCA.png"
          alt="Logo"
          className="logo"
        />
      </div>

      <div className="login-form">

        <label>USUARIO</label>
        <input
          type="text"
          value={usuario}
          onChange={(e) => setUsuario(e.target.value)}
          placeholder="Ingrese su usuario"
        />

        <label>CONTRASEÑA</label>
        <input
          type="password"
          value={contrasena}
          onChange={(e) => setContrasena(e.target.value)}
          placeholder="Ingrese su contraseña"
        />

        {error && <p className="error">{error}</p>}

        <button onClick={handleLogin}>INGRESAR</button>
      </div>
    </div>
  );
}
