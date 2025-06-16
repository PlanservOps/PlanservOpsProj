import { Navigate } from "react-router-dom";

export function PrivateRoute({ children, roleRequired }) {
  const token = localStorage.getItem("token");
  if (!token) return <Navigate to="/login" />;

  let userRole = null;
  try {
    const payload = JSON.parse(atob(token.split('.')[1]));
    userRole = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    console.log("Role do usuário:", userRole);
  } catch (e) {
    console.log("Erro ao decodificar token:", e);
    return <Navigate to="/login" />;
  }

  if (!userRole) return <Navigate to="/login" />;

  const allowed = Array.isArray(roleRequired)
    ? roleRequired.includes(userRole)
    : userRole === roleRequired;

  console.log("Role permitida?", allowed);

  if (!allowed) return <Navigate to="/" />;

  return children;
}