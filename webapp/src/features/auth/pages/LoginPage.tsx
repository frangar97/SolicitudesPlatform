import { useState, FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import { solicitudApi } from "../../../helpers/client";

export const LoginPage = () => {
    const navigation = useNavigate();
    const [codigo, setCodigo] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        try {
            e.preventDefault();

            if (codigo === "" || password === "") {
                alert("Por favor, ingrese usuario y contraseña");
                return;
            }

            const request = await solicitudApi.post<{ token: string }>(`/api/auth/login`, { codigo, password });
            localStorage.setItem("token", request.data.token);
            navigation("/", { replace: true });
        } catch (err) {

        }
    }

    return (
        <div className="container">
            <div className="col-md-6 offset-md-3">
                <h2>Login</h2>
                <hr />

                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label className="form-label">
                            Usuario
                        </label>
                        <input
                            type="text"
                            className="form-control"
                            value={codigo}
                            onChange={(e) => setCodigo(e.target.value)}
                        />
                    </div>

                    <div className="mb-3">
                        <label className="form-label">
                            Contraseña:
                        </label>
                        <input
                            type="password"
                            className="form-control"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>

                    <hr />

                    <input
                        type="submit"
                        className="btn btn-primary"
                        value="Iniciar sesion"
                    />


                </form>
            </div>
        </div>
    )
}