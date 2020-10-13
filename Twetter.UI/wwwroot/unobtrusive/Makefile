test:
	@node node_modules/lab/bin/lab -S -T node_modules/lab-babel 'test/'
test-cov:
	@node node_modules/lab/bin/lab -t 100 -S -T node_modules/lab-babel 'test/'
test-cov-html:
	@node node_modules/lab/bin/lab -r console -r html -o coverage.html -S -T node_modules/lab-babel 'test/'
test-coveralls:
	@node node_modules/lab/bin/lab -t 100 -r console -r lcov -S -T node_modules/lab-babel 'test/' | ./node_modules/coveralls/bin/coveralls.js

.PHONY: test test-cov test-cov-html test-coveralls
