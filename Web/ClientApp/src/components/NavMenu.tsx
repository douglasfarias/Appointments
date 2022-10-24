import * as React from "react";
import {
	Button,
	Collapse,
	Container,
	Navbar,
	NavbarBrand,
	NavbarToggler,
	NavItem,
	NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";

export default class NavMenu extends React.PureComponent<{}, { isOpen: boolean }> {
	public state = {
		isOpen: false,
	};

	public render() {
		return (
			<header>
				<Navbar className="navbar-expand-sm bg-dark" dark>
					<Container>
						<NavbarBrand tag={Link} to="/">
							Agendamentos
						</NavbarBrand>
						<Button color="dark" className="rounded-circle">
							<i className="bi bi-person"></i>
						</Button>
					</Container>
				</Navbar>
			</header>
		);
	}

	private toggle = () => {
		this.setState({
			isOpen: !this.state.isOpen,
		});
	};
}
