import * as React from "react";
import { connect } from "react-redux";
import Calendar from "../components/Calendar";

const Home = () => <Calendar />;

export default connect()(Home);
