import { useEffect } from "react";
import { Link, Outlet, useNavigate } from "react-router-dom";

export const AppPage = () => {
    const navigation = useNavigate();

    useEffect(() => {
        const token = localStorage.getItem("token") || "";

        if (token === "") {
            navigation("/login", { replace: true });
        }
    }, []);

    const logOut = () => {
        localStorage.removeItem("token");
        navigation("/login", { replace: true });
    }

    return (
        <div className="container">
            <div className="row">
                <div className="col">
                    <h1 className="mt-3">SolicitudesPlatform</h1>
                </div>
                <div className="col text-end">

                    <a href="#!" onClick={logOut}>
                        <span className="badge bg-danger">Logout</span>
                    </a>

                </div>
                <hr className="mb-3"></hr>
            </div>

            <div className="row">
                <div className="col-md-2">
                    <nav>
                        <div className="list-group">
                            <Link to="/" className="list-group-item list-group-item-action">
                                Home
                            </Link>
                            <Link
                                to="/usuarios"
                                className="list-group-item list-group-item-action"
                            >
                                Usuarios
                            </Link>
                            <Link
                                to="/solicitudes"
                                className="list-group-item list-group-item-action"
                            >
                                Solicitudes
                            </Link>
                            <Link
                                to="/tipos-solicitudes"
                                className="list-group-item list-group-item-action"
                            >
                                Tipos de solicitudes
                            </Link>
                            <Link
                                to="/usuario-zona"
                                className="list-group-item list-group-item-action"
                            >
                                Usuario/Zona
                            </Link>
                            <Link
                                to="/usuario-tiposolicitud"
                                className="list-group-item list-group-item-action"
                            >
                                Usuario/Tipo Solicitud
                            </Link>
                        </div>
                    </nav>
                </div>
                <div className="col-md-10">
                    <Outlet />
                </div>
            </div>
        </div>
    );
}