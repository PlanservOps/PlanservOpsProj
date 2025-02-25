import { Link } from "react-router-dom";
import logo from '../../assets/images/planservlogocut.png'

const Header=()=>{
    return(
        <>
            <header className="d-flex align-items-center">
                <div className="container-fluid w-100">
                    <div className="row d-flex align-items-center">
                        <div className="col-xs-3">
                            <Link to={"./>"}><img src={logo} className="logo"/></Link>
                        </div>
                    </div>
                </div>
            </header>
        </>
    )
}

export default Header;