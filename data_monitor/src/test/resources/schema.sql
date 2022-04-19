DELETE FROM Container;
INSERT INTO Container(id, docekr_id, names, image) VALUES ('data_collector','0264d2962ddb8f8c8dd4d3a1ad759307b133e048dcf0784e7441060f53bcb8cc','/collector,','data_collector');
INSERT INTO Container(id, docekr_id, names, image) VALUES ('questdb/questdb:latest','d73435879a5bd284de8ec4459fb43b68dd5464162f2bc965e4a5561408401124','/questdb,','questdb/questdb:latest');
INSERT INTO Container(id, docekr_id, names, image) VALUES ('openzipkin/zipkin','5aa30d8a45743cba9eb75f52bb6c52c5fb96c4a7346f996147b361e6523c2ef3','/dapr_zipkin,','openzipkin/zipkin');


DELETE FROM CPU;
INSERT INTO CPU(Container_id ,u_space_pr ,k_space_pr ,u_space_ms ,k_space_ms ,throttle_ns ,throttle_cnt ,total_ns ,total_pr ,date_time ) VALUES ('data_collector',1192,198,60,10,0,0,51,1027,'2022-01-04T13:59:30.204119Z');
INSERT INTO CPU(Container_id ,u_space_pr ,k_space_pr ,u_space_ms ,k_space_ms ,throttle_ns ,throttle_cnt ,total_ns ,total_pr ,date_time ) VALUES ('data_collector',1192,198,60,10,0,0,51,1027,'2022-01-04T13:59:33.204119Z');

DELETE FROM Memory;
INSERT INTO Memory(mem_used ,mem_swap_used ,rss ,cacheC ,swap ,mem_limit ,mem_swap_limit ,mem_hit_cnt ,mem_swap_hit_cnt ,date_time ,Container_id ) VALUES (2306048,2301952,675840,1216512,0,0,0,0,0,'2021-11-29T11:32:13.866436Z','data_collector');
INSERT INTO Memory(mem_used ,mem_swap_used ,rss ,cacheC ,swap ,mem_limit ,mem_swap_limit ,mem_hit_cnt ,mem_swap_hit_cnt ,date_time ,Container_id ) VALUES (2306048,2301952,675840,1216512,0,0,0,0,0,'2021-11-29T11:33:16.866436Z','data_collector');

DELETE FROM IO;
INSERT INTO IO(read ,write ,date_time ,Container_id ) VALUES (4096,0,'2021-11-29T11:32:23.973616Z','data_collector');
INSERT INTO IO(read ,write ,date_time ,Container_id ) VALUES (4096,0,'2021-11-29T11:33:23.973616Z','data_collector');

DELETE FROM NET;
INSERT INTO NET(receive ,receive_error ,receive_error_total ,transmit ,transmit_error ,transmit_error_total ,date_time ,Container_id) VALUES (50445,0,0,38958,0,0,'2021-11-29T11:32:34.052179Z','data_collector');
INSERT INTO NET(receive ,receive_error ,receive_error_total ,transmit ,transmit_error ,transmit_error_total ,date_time ,Container_id) VALUES (50445,0,0,38958,0,0,'2021-11-29T11:34:34.052179Z','data_collector');
