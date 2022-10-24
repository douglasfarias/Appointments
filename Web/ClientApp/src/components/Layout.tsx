import * as React from "react";
import { Container } from "reactstrap";
import NavMenu from "./NavMenu";

export default (props: { children?: React.ReactNode }) => (
	<React.Fragment>
		{/* <NavMenu /> */}
		<Container className="pb-3 bg-dark text-light" fluid>
			{props.children}
		</Container>
	</React.Fragment>
);
